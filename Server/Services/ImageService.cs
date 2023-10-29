using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class ImageService : IModelService<Image, int>
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public ImageService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Image>> Create(Image item)
        {
            try
            {
                sTIMULUSContext.Image.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Image.Contains(item))
                {
                    return new APIResponse<Image>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Image>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Image>(null, 500, $"Erreur lors de la création du model : {typeof(Image).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Image.Where(item => item.ImageId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Image.FindAsync(id);
                    sTIMULUSContext.Image.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Image).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Image).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Image).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Image>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Image.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Image>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Image>(null, 404, $"{typeof(Image).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Image>(null, 500, $"Erreur lors de la récupération du model {typeof(Image).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Image>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Image.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Image>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Image>>(null, 404, $"{typeof(Image).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Image>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Image).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Image>>> GetFromParentId(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Image.Where(item => item.ImageId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Image>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Image>>(null, 404, $"{typeof(Image).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Image>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Image).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Image>> Update(int id, Image item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Image.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Image>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Image>(null, 404, $"{typeof(Image).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Image>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Image).Name}. Message : {ex.Message}.");
            }
        }
    }
}
