using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class TexteFormaterService : IModelService<TexteFormater, int>
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public async Task<APIResponse<TexteFormater>> Create(TexteFormater item)
        {
            try
            {
                sTIMULUSContext.TexteFormater.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.TexteFormater.Contains(item))
                {
                    return new APIResponse<TexteFormater>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<TexteFormater>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<TexteFormater>(null, 500, $"Erreur lors de la création du model : {typeof(TexteFormater).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.TexteFormater.Where(item => item.TexteFormaterId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.TexteFormater.FindAsync(id);
                    sTIMULUSContext.TexteFormater.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(TexteFormater).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(TexteFormater).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(TexteFormater).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<TexteFormater>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.TexteFormater.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<TexteFormater>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<TexteFormater>(null, 404, $"{typeof(TexteFormater).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<TexteFormater>(null, 500, $"Erreur lors de la récupération du model {typeof(TexteFormater).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<TexteFormater>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.TexteFormater.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<TexteFormater>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<TexteFormater>>(null, 404, $"{typeof(TexteFormater).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<TexteFormater>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(TexteFormater).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<TexteFormater>>> GetFromParentId(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.TexteFormater.Where(item => item.TexteFormaterId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<TexteFormater>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<TexteFormater>>(null, 404, $"{typeof(Code).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<TexteFormater>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(TexteFormater).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<TexteFormater>> Update(int id, TexteFormater item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.TexteFormater.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<TexteFormater>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<TexteFormater>(null, 404, $"{typeof(TexteFormater).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<TexteFormater>(null, 500, $"Erreur lors de la mise à jour du model {typeof(TexteFormater).Name}. Message : {ex.Message}.");
            }
        }
    }
}
