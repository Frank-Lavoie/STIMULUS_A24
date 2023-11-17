using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class VideoService : IVideoService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public VideoService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Video>> Create(Video item)
        {
            try
            {
                sTIMULUSContext.Video.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Video.Contains(item))
                {
                    return new APIResponse<Video>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Video>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Video>(null, 500, $"Erreur lors de la création du model : {typeof(Video).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Video.Where(item => item.VideoId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Video.FindAsync(id);
                    sTIMULUSContext.Video.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Video).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Video).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Video).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Video>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Video.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Video>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Video>(null, 404, $"{typeof(Video).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Video>(null, 500, $"Erreur lors de la récupération du model {typeof(Video).Name}. Message : {ex.Message}.");
            }
        }      
        public async Task<APIResponse<IEnumerable<Video>>> GetAll()
        {
            try                
            {
                var itemList = await sTIMULUSContext.Video.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Video>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Video>>(null, 404, $"{typeof(Video).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Video>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Video).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Video>>> GetAllById(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Video.Where(item => item.VideoId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Video>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Video>>(null, 404, $"{typeof(Video).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Video>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Video).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Video>> Update(int id, Video item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Video.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Video>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Video>(null, 404, $"{typeof(Video).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Video>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Video).Name}. Message : {ex.Message}.");
            }
        }
    }
}
