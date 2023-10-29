using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class LienUtileService : IModelService<LienUtile, int>
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public LienUtileService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<LienUtile>> Create(LienUtile item)
        {
            try
            {
                sTIMULUSContext.LienUtile.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.LienUtile.Contains(item))
                {
                    return new APIResponse<LienUtile>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<LienUtile>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<LienUtile>(null, 500, $"Erreur lors de la création du model : {typeof(LienUtile).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.LienUtile.Where(item => item.LienUtileId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.LienUtile.FindAsync(id);
                    sTIMULUSContext.LienUtile.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(LienUtile).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(LienUtile).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(LienUtile).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<LienUtile>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.LienUtile.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<LienUtile>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<LienUtile>(null, 404, $"{typeof(LienUtile).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<LienUtile>(null, 500, $"Erreur lors de la récupération du model {typeof(LienUtile).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<LienUtile>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.LienUtile.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<LienUtile>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<LienUtile>>(null, 404, $"{typeof(LienUtile).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<LienUtile>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(LienUtile).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<LienUtile>>> GetFromParentId(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.LienUtile.Where(item => item.GrapheId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<LienUtile>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<LienUtile>>(null, 404, $"{typeof(LienUtile).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<LienUtile>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(LienUtile).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<LienUtile>> Update(int id, LienUtile item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.LienUtile.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<LienUtile>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<LienUtile>(null, 404, $"{typeof(LienUtile).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<LienUtile>(null, 500, $"Erreur lors de la mise à jour du model {typeof(LienUtile).Name}. Message : {ex.Message}.");
            }
        }
    }
}
