using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Linq;

namespace STIMULUS_V2.Server.Services
{
    public class FichierSauvegardeService : IFichierSauvegardeService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public FichierSauvegardeService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<FichierSauvegarde>> Create(FichierSauvegarde item)
        {
            try
            {
                sTIMULUSContext.FichierSauvegarde.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.FichierSauvegarde.Contains(item))
                {
                    return new APIResponse<FichierSauvegarde>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<FichierSauvegarde>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<FichierSauvegarde>(null, 500, $"Erreur lors de la création du model : {typeof(FichierSauvegarde).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.FichierSauvegarde.Where(item => item.FichierSauvegardeId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.FichierSauvegarde.FindAsync(id);
                    sTIMULUSContext.FichierSauvegarde.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(FichierSauvegarde).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(FichierSauvegarde).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(FichierSauvegarde).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<FichierSauvegarde>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.FichierSauvegarde.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<FichierSauvegarde>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<FichierSauvegarde>(null, 404, $"{typeof(FichierSauvegarde).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<FichierSauvegarde>(null, 500, $"Erreur lors de la récupération du model {typeof(FichierSauvegarde).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<FichierSauvegarde>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.FichierSauvegarde.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<FichierSauvegarde>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<FichierSauvegarde>>(null, 404, $"{typeof(FichierSauvegarde).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<FichierSauvegarde>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(FichierSauvegarde).Name}. Message : {ex.Message}.");
            }
        }

        public Task<APIResponse<IEnumerable<FichierSauvegarde>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<FichierSauvegarde>> Update(int id, FichierSauvegarde item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.FichierSauvegarde.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<FichierSauvegarde>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<FichierSauvegarde>(null, 404, $"{typeof(FichierSauvegarde).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<FichierSauvegarde>(null, 500, $"Erreur lors de la mise à jour du model {typeof(FichierSauvegarde).Name}. Message : {ex.Message}.");
            }
        }
    }
}
