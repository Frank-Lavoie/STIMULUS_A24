using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class StatusGrapheService : IModelService<StatusGraphe, string>
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public StatusGrapheService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<StatusGraphe>> Create(StatusGraphe item)
        {
            try
            {
                sTIMULUSContext.StatusGraphe.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.StatusGraphe.Contains(item))
                {
                    return new APIResponse<StatusGraphe>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<StatusGraphe>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<StatusGraphe>(null, 500, $"Erreur lors de la création du model : {typeof(StatusGraphe).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(string id)
        {
            try
            {
                if (sTIMULUSContext.StatusGraphe.Where(item => item.Code == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.StatusGraphe.FindAsync(id);
                    sTIMULUSContext.StatusGraphe.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(StatusGraphe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(StatusGraphe).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(StatusGraphe).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<StatusGraphe>> Get(string id)
        {
            try
            {
                var item = await sTIMULUSContext.StatusGraphe.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<StatusGraphe>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<StatusGraphe>(null, 404, $"{typeof(StatusGraphe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<StatusGraphe>(null, 500, $"Erreur lors de la récupération du model {typeof(StatusGraphe).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<StatusGraphe>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.StatusGraphe.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<StatusGraphe>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<StatusGraphe>>(null, 404, $"{typeof(StatusGraphe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<StatusGraphe>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(StatusGraphe).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<StatusGraphe>>> GetFromParentId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<StatusGraphe>> Update(string id, StatusGraphe item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.StatusGraphe.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<StatusGraphe>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<StatusGraphe>(null, 404, $"{typeof(StatusGraphe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<StatusGraphe>(null, 500, $"Erreur lors de la mise à jour du model {typeof(StatusGraphe).Name}. Message : {ex.Message}.");
            }
        }
    }
}
