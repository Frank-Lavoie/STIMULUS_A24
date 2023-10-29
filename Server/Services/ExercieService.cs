using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Linq;

namespace STIMULUS_V2.Server.Services
{
    public class ExercieService : IModelService<Exercice, int>
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public ExercieService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Exercice>> Create(Exercice item)
        {
            try
            {
                sTIMULUSContext.Exercice.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Exercice.Contains(item))
                {
                    return new APIResponse<Exercice>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Exercice>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Exercice>(null, 500, $"Erreur lors de la création du model : {typeof(Exercice).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Exercice.Where(item => item.ExerciceId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Exercice.FindAsync(id);
                    sTIMULUSContext.Exercice.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Exercice).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Exercice).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Exercice).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Exercice>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Exercice.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Exercice>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Exercice>(null, 404, $"{typeof(Exercice).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Exercice>(null, 500, $"Erreur lors de la récupération du model {typeof(Exercice).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Exercice>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Exercice.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Exercice>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Exercice>>(null, 404, $"{typeof(Exercice).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Exercice>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Exercice).Name}. Message : {ex.Message}.");
            }
        }

        public Task<APIResponse<IEnumerable<Exercice>>> GetFromParentId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<Exercice>> Update(int id, Exercice item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Exercice.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Exercice>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Exercice>(null, 404, $"{typeof(Exercice).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Exercice>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Exercice).Name}. Message : {ex.Message}.");
            }
        }
    }
}
