using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class ImportanceService : IModelService<Importance, int>
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public ImportanceService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Importance>> Create(Importance item)
        {
            try
            {
                sTIMULUSContext.Importance.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Importance.Contains(item))
                {
                    return new APIResponse<Importance>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Importance>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Importance>(null, 500, $"Erreur lors de la création du model : {typeof(Importance).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Importance.Where(item => item.Code == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Importance.FindAsync(id);
                    sTIMULUSContext.Importance.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Importance).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Importance).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Importance).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Importance>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Importance.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Importance>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Importance>(null, 404, $"{typeof(Importance).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Importance>(null, 500, $"Erreur lors de la récupération du model {typeof(Importance).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Importance>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Importance.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Importance>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Importance>>(null, 404, $"{typeof(Importance).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Importance>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Importance).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Importance>>> GetFromParentId(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Importance.Where(item => item.Code == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Importance>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Importance>>(null, 404, $"{typeof(Importance).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Importance>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Importance).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Importance>> Update(int id, Importance item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Importance.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Importance>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Importance>(null, 404, $"{typeof(Importance).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Importance>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Importance).Name}. Message : {ex.Message}.");
            }
        }
    }
}
