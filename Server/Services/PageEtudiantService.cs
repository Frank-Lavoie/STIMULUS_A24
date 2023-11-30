using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Collections;

namespace STIMULUS_V2.Server.Services
{
    public class PageEtudiantService : IPageEtudiantService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public PageEtudiantService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<double>> CalculerPourcentage(int groupeId, string codeDa, string professeurIdentifiant)
        {
            try
            {
                var sommePts = await CalculerSommePtsEtudiant(codeDa, groupeId);
                var sommeImportance = await CalculerSommePtsGroupe(professeurIdentifiant, groupeId);

                if (sommePts != null && sommeImportance.Data != 0)
                {
                    double pourcentage = sommePts.Data / sommeImportance.Data * 100;

                    //int pourcentageArrondi = (int)Math.Round(pourcentage);/*Arrondi ou non ?*/

                    return new APIResponse<double>(pourcentage, 200, "Succès");
                }
                else
                {
                    return new APIResponse<double>(0, 500, "Erreur lors du calcul du pourcentage. Vérifiez les résultats des sous-calculs.");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<double>(0, 500, $"Erreur lors du calcul du pourcentage. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<double>> CalculerSommePtsEtudiant(string codeDA, int groupeId)
        {
            try
            {
                var sommePts = await (
                    from imp in sTIMULUSContext.Importance
                    join page in sTIMULUSContext.Page on imp.Code equals page.ImportanceId
                    join pageEtudiant in sTIMULUSContext.Page_Etudiant on page.PageId equals pageEtudiant.PageId
                    join etudiant in sTIMULUSContext.Etudiant on pageEtudiant.CodeDA equals etudiant.Identifiant
                    join groupeEtudiant in sTIMULUSContext.Groupe_Etudiant on etudiant.Identifiant equals groupeEtudiant.CodeDA
                    where groupeEtudiant.CodeDA == codeDA && groupeEtudiant.GroupeId == groupeId
                    select imp.Pts
                ).SumAsync();

                return new APIResponse<double>(sommePts, 200, "Succès");
            }
            catch (Exception ex)
            {
                return new APIResponse<double>(0, 500, $"Erreur lors du calcul de la somme des points. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<double>> CalculerSommePtsGroupe(string professeurIdentifiant, int groupeId)
        {
            try
            {
                var sommeImportance = await (
                    from imp in sTIMULUSContext.Importance
                    join page in sTIMULUSContext.Page on imp.Code equals page.ImportanceId
                    join noeud in sTIMULUSContext.Noeud on page.NoeudId equals noeud.NoeudId
                    join graphe in sTIMULUSContext.Graphe on noeud.GrapheId equals graphe.GrapheId
                    join groupe in sTIMULUSContext.Groupe on graphe.GroupeId equals groupe.GroupeId
                    join professeur in sTIMULUSContext.Professeur on groupe.ProfesseurId equals professeur.Identifiant
                    where groupe.GroupeId == groupeId && professeur.Identifiant == professeurIdentifiant
                    select imp.Pts
                ).SumAsync();

                return new APIResponse<double>(sommeImportance, 200, "Succès");
            }
            catch (Exception ex)
            {
                return new APIResponse<double>(0, 500, $"Erreur lors du calcul de la somme d'importance. Message : {ex.Message}");
            }
        }
    }
}