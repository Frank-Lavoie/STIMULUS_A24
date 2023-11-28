using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class ReferenceService : IReferenceService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public ReferenceService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Reference>> Create(Reference item)
        {
            try
            {
                sTIMULUSContext.Reference.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Reference.Contains(item))
                {
                    return new APIResponse<Reference>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Reference>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Reference>(null, 500, $"Erreur lors de la création du model : {typeof(Reference).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Reference.Where(item => item.ReferenceId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Reference.FindAsync(id);
                    sTIMULUSContext.Reference.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Reference).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Reference).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Reference).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Reference>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Reference.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Reference>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Reference>(null, 404, $"{typeof(Reference).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Reference>(null, 500, $"Erreur lors de la récupération du model {typeof(Reference).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Reference>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Reference.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Reference>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Reference>>(null, 404, $"{typeof(Reference).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Reference>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Reference).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Reference>>> GetAllById(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Reference.Where(item => item.ReferenceId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Reference>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Reference>>(null, 404, $"{typeof(Reference).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Reference>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Reference).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Reference>> Update(int id, Reference item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Reference.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Reference>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Reference>(null, 404, $"{typeof(Reference).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Reference>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Reference).Name}. Message : {ex.Message}.");
            }
        }
    }
}
