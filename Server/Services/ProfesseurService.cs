using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class ProfesseurService : IModelService<Professeur, string>
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public ProfesseurService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Professeur>> Create(Professeur item)
        {
            try
            {
                sTIMULUSContext.Professeur.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Professeur.Contains(item))
                {
                    return new APIResponse<Professeur>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Professeur>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Professeur>(null, 500, $"Erreur lors de la création du model : {typeof(Professeur).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(string id)
        {
            try
            {
                if (sTIMULUSContext.Professeur.Where(item => item.NumEmploye == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Professeur.FindAsync(id);
                    sTIMULUSContext.Professeur.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Professeur).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Professeur).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Professeur).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Professeur>> Get(string id)
        {
            try
            {
                var item = await sTIMULUSContext.Professeur.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Professeur>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Professeur>(null, 404, $"{typeof(Professeur).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Professeur>(null, 500, $"Erreur lors de la récupération du model {typeof(Professeur).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Professeur>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Professeur.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Professeur>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Professeur>>(null, 404, $"{typeof(Professeur).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Professeur>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Professeur).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Professeur>>> GetFromParentId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<Professeur>> Update(string id, Professeur item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Professeur.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Professeur>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Professeur>(null, 404, $"{typeof(Professeur).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Professeur>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Professeur).Name}. Message : {ex.Message}.");
            }
        }
    }
}
