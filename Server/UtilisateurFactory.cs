using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Models.Authentication;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server
{
    public class UtilisateurFactory
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public UtilisateurFactory(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<IdentityResult> CreerUtilisateur(string nom, string prenom, string email, string motDePasse)
        {
            try
            {
                var utilisateurId = email.Split('@')[0];

                if (await sTIMULUSContext.Utilisateur.AnyAsync(utilisateur => utilisateur.Identifiant == utilisateurId))
                {
                    return IdentityResult.Failed(new IdentityError { Description = "L'identifiant existe déjà." });
                }

                Utilisateur utilisateur;

                if (email.Contains("@etu.cegepjonquiere.ca"))
                {
                    var etudiant = new Etudiant { Identifiant = utilisateurId, Nom = nom, Prenom = prenom, Email = email, MotDePasse = BCrypt.Net.BCrypt.HashPassword(motDePasse), Role = "ETUDIANT" };
                    utilisateur = etudiant;
                }
                else if (email.Contains("@cegepjonquiere.ca"))
                {
                    var professeur = new Professeur { Identifiant = utilisateurId, Nom = nom, Prenom = prenom, Email = email, MotDePasse = BCrypt.Net.BCrypt.HashPassword(motDePasse), Role = "PROFESSEUR" };
                    utilisateur = professeur;
                }
                else
                {
                    return IdentityResult.Failed(new IdentityError { Description = "N'est pas associer au domaine du cegep" });
                }

                sTIMULUSContext.Add(utilisateur);
                await sTIMULUSContext.SaveChangesAsync();

                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError { Description = $"Erreur lors de la création de l'utilisateur : {ex.Message}" });
            }
        }
    }
}
