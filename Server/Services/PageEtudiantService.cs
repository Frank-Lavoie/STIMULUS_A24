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

        public async Task<APIResponse<double>> CalculerPourcentage(int groupeId, string codeDa)
        {
            try
            {
                var sommePts = await CalculerSommePtsEtudiant(codeDa, groupeId);
                var sommeImportance = await CalculerSommePtsGroupe(groupeId);

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
                var sommePts = sTIMULUSContext.Importance
                    .Join(sTIMULUSContext.Page, imp => imp.Code, page => page.ImportanceId, (imp, page) => new { imp, page })
                    .Join(sTIMULUSContext.Page_Etudiant, join1 => join1.page.PageId, pe => pe.PageId, (join1, pe) => new { join1.imp, join1.page, pe })
                    .Join(sTIMULUSContext.Etudiant, join2 => join2.pe.CodeDA, etudiant => etudiant.Identifiant, (join2, etudiant) => new { join2.imp, join2.page, join2.pe, etudiant })
                    .Join(sTIMULUSContext.Groupe_Etudiant, join3 => join3.etudiant.Identifiant, ge => ge.CodeDA, (join3, ge) => new { join3.imp, join3.page, join3.pe, join3.etudiant, ge })
                    .Where(result => result.ge.CodeDA == codeDA && result.ge.GroupeId == groupeId)
                    .Sum(result => result.imp.Pts);

                return new APIResponse<double>(sommePts, 200, "Succès");
            }
            catch (Exception ex)
            {
                return new APIResponse<double>(0, 500, $"Erreur lors du calcul de la somme des points. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<double>> CalculerSommePtsGroupe(int groupeId)
        {
            try
            {
                var sommeImportance = sTIMULUSContext.Importance
                    .Join(sTIMULUSContext.Page, imp => imp.Code, page => page.ImportanceId, (imp, page) => new { imp, page })
                    .Join(sTIMULUSContext.Noeud, join1 => join1.page.NoeudId, noeud => noeud.NoeudId, (join1, noeud) => new { join1.imp, join1.page, noeud })
                    .Join(sTIMULUSContext.Graphe, join2 => join2.noeud.GrapheId, graphe => graphe.GrapheId, (join2, graphe) => new { join2.imp, join2.page, join2.noeud, graphe })
                    .Join(sTIMULUSContext.Groupe, join3 => join3.graphe.GroupeId, groupe => groupe.GroupeId, (join3, groupe) => new { join3.imp, join3.page, join3.noeud, join3.graphe, groupe })
                    .Where(result => result.groupe.GroupeId == groupeId)
                    .Sum(result => result.imp.Pts);

                return new APIResponse<double>(sommeImportance, 200, "Succès");
            }
            catch (Exception ex)
            {
                return new APIResponse<double>(0, 500, $"Erreur lors du calcul de la somme des points. Message : {ex.Message}");
            }
        }
    }
}