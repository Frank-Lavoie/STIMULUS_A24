using Microsoft.EntityFrameworkCore;
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
