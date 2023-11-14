using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using STIMULUS_V2.Client;
using STIMULUS_V2.Shared.Models.Authentication;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace STIMULUS_V2.Client.CustomAuthentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        //Constructor with instances.
        private ClaimsPrincipal anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        private readonly ILocalStorageService localStorageService;
        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        // Override Default Method to authenticate and deauthenticate user during page navigations.
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await localStorageService.GetItemAsync<string>("token");
            if (string.IsNullOrEmpty(token)) return await Task.FromResult(new AuthenticationState(anonymous));

            try
            {
                var userSession = DeSerializedUserSession(token);              
                var (Identifiant, role) = await GetClaimsFromJWT(userSession.Token!);
                return await Task.FromResult(new AuthenticationState(SetClaimsPrincipal(Identifiant, role)));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(anonymous));
            }

        }

        // Update Token by setting up or deleting from local storage
        public async Task UpdateAuthenticationState(SessionUtilisateur userSession)
        {

            ClaimsPrincipal claimsPrincipal;
            if (!string.IsNullOrEmpty(userSession.Token))
            {
                await localStorageService.SetItemAsync("token", SerializedUserSession(userSession));
                var (Identifiant, role) = await GetClaimsFromJWT(userSession.Token!);
                claimsPrincipal = SetClaimsPrincipal(Identifiant, role);
            }
            else
            {
                claimsPrincipal = anonymous;
                await localStorageService.RemoveItemAsync("token");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        // General methods
        private static ClaimsPrincipal SetClaimsPrincipal(string Identifiant, string role)
        {
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new(ClaimTypes.Name, Identifiant),
                    new(ClaimTypes.Role, role)
                }, "JwtAuth"));
            return claimsPrincipal;
        }

        private static async Task<(string Identifiant, string role)> GetClaimsFromJWT(string jwt)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwt);
                var claims = token.Claims;

                var role = claims.First(_ => _.Type == ClaimTypes.Role).Value;
                var Identifiant = claims.First(_ => _.Type == ClaimTypes.Name).Value;

                return (Identifiant.ToString(), role);
            }
            catch { throw new Exception("something happened"); }
        }

        private static string SerializedUserSession(SessionUtilisateur userSession)
        {
            return JsonConvert.SerializeObject(userSession);
        }

        private static SessionUtilisateur DeSerializedUserSession(string SerialisedString)
        {
            return JsonConvert.DeserializeObject<SessionUtilisateur>(SerialisedString)!;
        }
    }
}
