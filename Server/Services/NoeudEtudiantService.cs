using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using STIMULUS_V2.Client.Shared.NoeudComponents;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class NoeudEtudiantService : INoeudEtudiantService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public NoeudEtudiantService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Noeud_Etudiant>> Create(Noeud_Etudiant item)
        {
            try
            {
                sTIMULUSContext.Noeud_Etudiant.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Noeud_Etudiant.Contains(item))
                {
                    return new APIResponse<Noeud_Etudiant>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Noeud_Etudiant>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Noeud_Etudiant>(null, 500, $"Erreur lors de la création du model : {typeof(Noeud_Etudiant).Name}. Message : {ex.Message}");
            }
        }        

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Noeud_Etudiant.Where(item => item.Noeud_EtudiantId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Noeud_Etudiant.FindAsync(id);
                    sTIMULUSContext.Noeud_Etudiant.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Noeud_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Noeud_Etudiant).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Noeud_Etudiant).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Noeud_Etudiant>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Noeud_Etudiant.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Noeud_Etudiant>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Noeud_Etudiant>(null, 404, $"{typeof(Noeud_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Noeud_Etudiant>(null, 500, $"Erreur lors de la récupération du model {typeof(Noeud_Etudiant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Noeud_Etudiant>> GetByNoeudId(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Noeud_Etudiant.Where(e => e.NoeudId == id).FirstOrDefaultAsync();

                if (item != null)
                {
                    return new APIResponse<Noeud_Etudiant>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Noeud_Etudiant>(null, 404, $"{typeof(Noeud_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Noeud_Etudiant>(null, 500, $"Erreur lors de la récupération du modèle {typeof(Noeud_Etudiant).Name}. Message : {ex.Message}.");
            }
        }
        public async Task<APIResponse<Noeud_Etudiant>> GetByNoeudAndDa(int id, string da)
        {
            try
            {
                var item = await sTIMULUSContext.Noeud_Etudiant.Where(e => e.NoeudId == id && e.CodeDA == da).FirstOrDefaultAsync();

                if (item != null)
                {
                    return new APIResponse<Noeud_Etudiant>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Noeud_Etudiant>(null, 404, $"{typeof(Noeud_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Noeud_Etudiant>(null, 500, $"Erreur lors de la récupération du modèle {typeof(Noeud_Etudiant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Noeud_Etudiant>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Noeud_Etudiant.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Noeud_Etudiant>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Noeud_Etudiant>>(null, 404, $"{typeof(Noeud_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Noeud_Etudiant>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Noeud_Etudiant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Noeud_Etudiant>>> GetAllById(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Noeud_Etudiant.Where(item => item.NoeudId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Noeud_Etudiant>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Noeud_Etudiant>>(null, 404, $"{typeof(Noeud_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Noeud_Etudiant>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Noeud_Etudiant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Noeud_Etudiant>>> GetAllNoeudForStudent(string id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Noeud_Etudiant.Where(item => item.Etudiant.Identifiant == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Noeud_Etudiant>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Noeud_Etudiant>>(null, 404, $"{typeof(Noeud_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Noeud_Etudiant>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Noeud_Etudiant).Name}. Message : {ex.Message}.");
            }
        }
        public async Task<APIResponse<bool>> GetProgression(string da, int graphe, int noeud)
        {
            try
            {
                var CodeDa = await sTIMULUSContext.Noeud_Etudiant.Where(e => e.CodeDA == da).FirstOrDefaultAsync();
                var Graphe = await sTIMULUSContext.Graphe.Where(e => e.GrapheId == graphe).FirstOrDefaultAsync();
                var ChildrenNode = await sTIMULUSContext.Noeud.Where(item => item.NoeudParentId == noeud).ToListAsync();
                var ParentNode = await GetByNoeudAndDa(noeud, da);

                foreach (var childNode in ChildrenNode)
                {
                    var ChildNode = await GetByNoeudAndDa(childNode.NoeudId, da);

                    if (Graphe.Status == GrapheStatus.DESACTIVER)
                    {
                        if (ParentNode.Data.Status == 0) // Noeud inital
                        {
                            if (ChildNode.Data.Status == 1) //Bloqué par le prof
                            {
                                ChildNode.Data.Status = 1;//Bloqué par le prof
                            }
                            else
                                ChildNode.Data.Status = 5; // Bloqué par le prof
                        }
                        else if (ParentNode.Data.Status == 5)
                        {
                            if (ChildNode.Data.Status == 1)//Bloqué par le prof
                            {
                                ChildNode.Data.Status = 1;//Bloqué par le prof
                            }
                            else
                                ChildNode.Data.Status = 5;
                        }
                        await Update(ChildNode.Data.Noeud_EtudiantId, ChildNode.Data);
                    }
                    else
                    {
                        if (ChildNode.Data != null)
                        {
                            if (ParentNode.Data.Status == 4 && childNode.Type == NoeudType.STRUCTURE && ChildNode.Data.Status == 2)
                            {

                                ChildNode.Data.Status = 4; // Bloqué par le prof

                                await Update(ChildNode.Data.Noeud_EtudiantId, ChildNode.Data);
                            }

                            else if (ParentNode.Data.Status == 1) // si la parent est bloqué par le prof
                            {
                                if (ChildNode.Data.Status == 1) // et quer les enfants sont aussi bloqué par le prof
                                {
                                    ChildNode.Data.Status = 1; // Bloqué par le prof
                                }
                                else // sinon
                                    ChildNode.Data.Status = 5; // bloqué par la progression
                            }

                            else if (ParentNode.Data.Status == 5) // si le parent est bloqué par la progression
                            {
                                if (ChildNode.Data.Status != 1) // Et que le prof n'a pas bloqué le noeud
                                {
                                    ChildNode.Data.Status = 5; // les enfants sont bloqué par la progression
                                }
                            }
                            else if (ParentNode.Data.Status == 2) // Si le parent est non  complété
                            {
                                if (ChildNode.Data.Status == 1) // Si l'enfant est bloqué par le prof
                                {
                                    ChildNode.Data.Status = 1; // Bloqué par le prof
                                }
                                else
                                {
                                    ChildNode.Data.Status = 5; // Bloqué par la progression
                                }
                            }
                            //OUVERTURE DE NOEUD ENFANT        
                            else if (ParentNode.Data.Status == 4 && ChildNode.Data.Status == 4) // si le parent et l'enfant son complétés
                            {
                                ChildNode.Data.Status = 4; // l'enfant est complété
                            }

                            else if (ParentNode.Data.Status == 4) // Si le parent est Complété
                            {
                                if (ChildNode.Data.Status == 1) // Si l'enfant est bloqué par le prof
                                {
                                    ChildNode.Data.Status = 1; // reste bloqué
                                }
                                else
                                {
                                    ChildNode.Data.Status = 2; // si non il est non complété
                                }
                            }
                            else if (ParentNode.Data.Status == 0 && ChildNode.Data.Status == 4) // si la parent est bloqué par le prof
                            {
                                if (ChildNode.Data.Status == 1) // et quer les enfants sont aussi bloqué par le prof
                                {
                                    ChildNode.Data.Status = 1; // Bloqué par le prof
                                }
                                else // sinon
                                    ChildNode.Data.Status = 4; // bloqué par la progression
                            }
                            else if (ParentNode.Data.Status == 0) // si la parent est bloqué par le prof
                            {
                                if (ChildNode.Data.Status == 1) // et quer les enfants sont aussi bloqué par le prof
                                {
                                    ChildNode.Data.Status = 1; // Bloqué par le prof
                                }
                                else // sinon
                                    ChildNode.Data.Status = 2; // bloqué par la progression
                            }
                        }
                        await Update(ChildNode.Data.Noeud_EtudiantId, ChildNode.Data); // Update chaque enfants du noeud parents
                    }
                } 
                return new APIResponse<bool>(true, 200, "Progression enregistré");
            }
            catch (Exception ex)
            {
                return new APIResponse<bool>(false, 500, "Erreur dans la progression");
            }
        }

        public async Task<APIResponse<Noeud_Etudiant>> Update(int id, Noeud_Etudiant item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Noeud_Etudiant.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Noeud_Etudiant>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Noeud_Etudiant>(null, 404, $"{typeof(Noeud_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Noeud_Etudiant>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Noeud_Etudiant).Name}. Message : {ex.Message}.");
            }
        }
    }
}
