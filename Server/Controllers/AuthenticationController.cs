using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System;
using STIMULUS_V2.Server.Data;
using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Shared.Models.Authentication;
using Serilog;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly STIMULUSContext sTIMULUSContext;
        private readonly UtilisateurFactory utilisateurFactory;
        private readonly IConfiguration config;
        public AuthenticationController(STIMULUSContext sTIMULUSContext, UtilisateurFactory utilisateurFactory, IConfiguration config)
        {
            this.sTIMULUSContext = sTIMULUSContext;
            this.utilisateurFactory = utilisateurFactory;
            this.config = config;
        }

        [HttpPost("Connexion")]
        [AllowAnonymous]
        public async Task<ActionResult<APIResponse<SessionUtilisateur>>> ConnexionUtilisateur(ConnexionVerification connexionVerification)
        {
            try
            {
                var existingUser = await sTIMULUSContext.Utilisateur.SingleOrDefaultAsync(user => user.Identifiant == connexionVerification.Identifiant);
                if (existingUser == null)
                {
                    return new APIResponse<SessionUtilisateur>(null, 400, "L'utilisateur n'existe pas.");
                }

                if (BCrypt.Net.BCrypt.Verify(connexionVerification.Password, existingUser.MotDePasse))
                {
                    var userRole = existingUser.Role;
                    if (string.IsNullOrEmpty(userRole))
                    {
                        return new APIResponse<SessionUtilisateur>(null, 400, "Le rôle de l'utilisateur n'est pas défini.");
                    }

                    var token = GenerateToken(connexionVerification.Identifiant, userRole);

                    var refreshToken = GenerateRefreshToken();

                    var existingUserToken = await sTIMULUSContext.TokenInfo.FirstOrDefaultAsync(token => token.UserId == existingUser.Identifiant);
                    if (existingUserToken is null)
                    {
                        sTIMULUSContext.TokenInfo.Add(new TokenInfo()
                        { RefreshToken = refreshToken, UserId = existingUser.Identifiant, TokenExpiry = DateTime.UtcNow.AddMinutes(2) });
                        await sTIMULUSContext.SaveChangesAsync();
                    }
                    else
                    {
                        existingUserToken.RefreshToken = refreshToken;
                        existingUserToken.TokenExpiry = DateTime.Now.AddMinutes(1);
                        await sTIMULUSContext.SaveChangesAsync();
                    }
                    return new APIResponse<SessionUtilisateur>(new SessionUtilisateur() { Token = token, RefreshToken = refreshToken }, 200, "Success");
                }
                return new APIResponse<SessionUtilisateur>(null, 400, "Le mot de passe est incorrect.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }
        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        private string GenerateToken(string? email, string? roleName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name,email!),
                new Claim(ClaimTypes.Role,roleName!)
            };
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //PRIVATE API ENDPOINTS
        //TODO: finishing clean-up code below while implementing APIResponse 

        // Account Registration
        [HttpPost("Inscription")]

        public async Task<IActionResult> UtilisateurInscription(InscriptionVerification inscriptionVerification)
        {
            var result = await utilisateurFactory.CreerUtilisateur(inscriptionVerification.Nom, inscriptionVerification.Prenom, inscriptionVerification.Email, inscriptionVerification.Password);

            if (result.Succeeded)
            {
                return Ok("Utilisateur inscrit avec succès");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        // Get total user in the database, ONLY Admin can do that.
        [HttpGet("total-users")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetTotalUsersCount()
        {
            var users = await sTIMULUSContext.Utilisateur.ToListAsync();
            return Ok(users.Count);
        }

        // Get Current User info, ONLY user can do that.
        [HttpGet("my-info/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetMyInfo(string identifiant)
        {
            var user = await sTIMULUSContext.Utilisateur.FirstOrDefaultAsync(utilisateur => utilisateur.Identifiant.Equals(identifiant));
            string info = $"Name : {user.Prenom}{Environment.NewLine}Email: {user.Email}";
            return Ok(info);
        }

        //PUBLIC API ENPOINT FOR GENERATING NEW REFRESH TOKEN AND AUTHENTICATION TOKEN
        [HttpPost("GetNewToken")]
        [AllowAnonymous]
        public async Task<ActionResult<SessionUtilisateur>> GetNewToken(SessionUtilisateur sessionUtilisateur)
        {
            if (sessionUtilisateur is null) return null!;
            var rToken = await sTIMULUSContext.TokenInfo.Where(_ => _.RefreshToken!.Equals(sessionUtilisateur.RefreshToken)).FirstOrDefaultAsync();

            // check if refresh token expiration date is due then.
            if (rToken is null) return null!;

            //Generate new refresh token if Due.
            string newRefreshToken = string.Empty;
            if (rToken.TokenExpiry < DateTime.Now)
                newRefreshToken = GenerateRefreshToken();

            //Generate new token by extracting the claims from the old jwt 
            var jwtToken = new JwtSecurityToken(sessionUtilisateur!.Token);
            var userClaims = jwtToken.Claims;

            //Get all claims from the token.
            var identifiant = userClaims.First(c => c.Type == ClaimTypes.Name).Value;
            var role = userClaims.First(c => c.Type == ClaimTypes.Role).Value;
            string newToken = GenerateToken(identifiant, role);

            //update refresh token in the DB
            var user = await sTIMULUSContext.Utilisateur.FirstOrDefaultAsync(utilisateur => utilisateur.Identifiant.Equals(identifiant));
            var rTokenUser = await sTIMULUSContext.TokenInfo.FirstOrDefaultAsync(token => token.UserId == user.Identifiant);

            if (!string.IsNullOrEmpty(newRefreshToken))
            {
                rTokenUser.RefreshToken = newRefreshToken;
                rTokenUser.TokenExpiry = DateTime.Now.AddMinutes(1);
                await sTIMULUSContext.SaveChangesAsync();
            }
            return Ok(new SessionUtilisateur() { Token = newToken, RefreshToken = newRefreshToken });
        }
    }
}
