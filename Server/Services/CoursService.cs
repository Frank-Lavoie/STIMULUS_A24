using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Linq;

namespace STIMULUS_V2.Server.Services
{
    public class CoursService : IModelService<Cours, int>
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public CoursService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Cours>> Create(Cours item)
        {
            try
            {
                sTIMULUSContext.Cours.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Cours.Contains(item))
                {
                    return new APIResponse<Cours>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Cours>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Cours>(null, 500, $"Erreur lors de la création du model : {typeof(Cours).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Cours.Where(item => item.CoursId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Cours.FindAsync(id);
                    sTIMULUSContext.Cours.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Cours).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Cours).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Cours).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Cours>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Cours.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Cours>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Cours>(null, 404, $"{typeof(Cours).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Cours>(null, 500, $"Erreur lors de la récupération du model {typeof(Cours).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Cours>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Cours.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Cours>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Cours>>(null, 404, $"{typeof(Cours).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Cours>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Cours).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Cours>>> GetFromParentId(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Cours.Where(item => item.GroupeId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Cours>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Cours>>(null, 404, $"{typeof(Cours).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Cours>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Cours).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Cours>> Update(int id, Cours item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Cours.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Cours>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Cours>(null, 404, $"{typeof(Cours).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Cours>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Cours).Name}. Message : {ex.Message}.");
            }
        }
    }
}
