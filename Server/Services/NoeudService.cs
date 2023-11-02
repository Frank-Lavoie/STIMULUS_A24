using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class NoeudService : IModelService<Noeud, int>
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public NoeudService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Noeud>> Create(Noeud item)
        {
            try
            {
                sTIMULUSContext.Noeud.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Noeud.Contains(item))
                {
                    return new APIResponse<Noeud>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Noeud>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Noeud>(null, 500, $"Erreur lors de la création du model : {typeof(Noeud).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Noeud.Where(item => item.NoeudId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Noeud.FindAsync(id);
                    sTIMULUSContext.Noeud.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Noeud).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Noeud).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Noeud).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Noeud>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Noeud.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Noeud>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Noeud>(null, 404, $"{typeof(Noeud).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Noeud>(null, 500, $"Erreur lors de la récupération du model {typeof(Noeud).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Noeud>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Noeud.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Noeud>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Noeud>>(null, 404, $"{typeof(Noeud).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Noeud>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Noeud).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Noeud>>> GetFromParentId(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Noeud.Where(item => item.NoeudParentId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Noeud>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Noeud>>(null, 404, $"{typeof(Noeud).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Noeud>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Noeud).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Noeud>> Update(int id, Noeud item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Noeud.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Noeud>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Noeud>(null, 404, $"{typeof(Noeud).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Noeud>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Noeud).Name}. Message : {ex.Message}.");
            }
        }
    }
}
