using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Linq;

namespace STIMULUS_V2.Server.Services
{
    public class FichierSourceService : IFichierSourceService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public FichierSourceService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<FichierSource>> Create(FichierSource item)
        {
            try
            {
                sTIMULUSContext.FichierSource.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.FichierSource.Contains(item))
                {
                    return new APIResponse<FichierSource>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<FichierSource>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<FichierSource>(null, 500, $"Erreur lors de la création du model : {typeof(FichierSource).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.FichierSource.Where(item => item.FichierSourceId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.FichierSource.FindAsync(id);
                    sTIMULUSContext.FichierSource.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(FichierSource).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(FichierSource).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(FichierSource).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<FichierSource>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.FichierSource.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<FichierSource>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<FichierSource>(null, 404, $"{typeof(FichierSource).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<FichierSource>(null, 500, $"Erreur lors de la récupération du model {typeof(FichierSource).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<FichierSource>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.FichierSource.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<FichierSource>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<FichierSource>>(null, 404, $"{typeof(FichierSource).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<FichierSource>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(FichierSource).Name}. Message : {ex.Message}.");
            }
        }

        public Task<APIResponse<IEnumerable<FichierSource>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<FichierSource>> Update(int id, FichierSource item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.FichierSource.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<FichierSource>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<FichierSource>(null, 404, $"{typeof(FichierSource).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<FichierSource>(null, 500, $"Erreur lors de la mise à jour du model {typeof(FichierSource).Name}. Message : {ex.Message}.");
            }
        }
    }
}
