using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Linq;

namespace STIMULUS_V2.Server.Services
{
    public class EtudiantService : IEtudiantService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public EtudiantService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Etudiant>> Create(Etudiant item)
        {
            try
            {
                sTIMULUSContext.Etudiant.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Etudiant.Contains(item))
                {
                    return new APIResponse<Etudiant>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Etudiant>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Etudiant>(null, 500, $"Erreur lors de la création du model : {typeof(Etudiant).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(string id)
        {
            try
            {
                if (sTIMULUSContext.Etudiant.Where(item => item.Identifiant == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Etudiant.FindAsync(id);
                    sTIMULUSContext.Etudiant.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Etudiant).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Etudiant).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Etudiant>> Get(string id)
        {
            try
            {
                var item = await sTIMULUSContext.Etudiant.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Etudiant>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Etudiant>(null, 404, $"{typeof(Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Etudiant>(null, 500, $"Erreur lors de la récupération du model {typeof(Etudiant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Etudiant>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Etudiant.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Etudiant>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Etudiant>>(null, 404, $"{typeof(Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Etudiant>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Etudiant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Etudiant>>> GetAllById(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Etudiant.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Etudiant>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Etudiant>>(null, 404, $"{typeof(Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Etudiant>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Etudiant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Etudiant>>> GetAllByIdentifiant(string id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Etudiant.Where(item => item.Identifiant == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Etudiant>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Etudiant>>(null, 404, $"{typeof(Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Etudiant>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Etudiant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Etudiant>> Update(string id, Etudiant item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Etudiant.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Etudiant>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Etudiant>(null, 404, $"{typeof(Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Etudiant>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Etudiant).Name}. Message : {ex.Message}.");
            }
        }
    }
}
