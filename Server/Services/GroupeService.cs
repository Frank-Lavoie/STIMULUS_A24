using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Linq;

namespace STIMULUS_V2.Server.Services
{
    public class GroupeService : IGroupeService
    {
        private readonly STIMULUSContext sTIMULUSContext;
        private DateTime dateDuJour = DateTime.Now.Date;

        public GroupeService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Groupe>> Create(Groupe item)
        {
            try
            {
                sTIMULUSContext.Groupe.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Groupe.Contains(item))
                {
                    return new APIResponse<Groupe>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Groupe>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Groupe>(null, 500, $"Erreur lors de la création du model : {typeof(Groupe).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Groupe.Where(item => item.GroupeId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Groupe.FindAsync(id);
                    sTIMULUSContext.Groupe.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Groupe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Groupe).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Groupe).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Groupe>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Groupe.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Groupe>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Groupe>(null, 404, $"{typeof(Groupe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Groupe>(null, 500, $"Erreur lors de la récupération du model {typeof(Groupe).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Groupe>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Groupe.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Groupe>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Groupe>>(null, 404, $"{typeof(Groupe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Groupe>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Groupe).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Groupe>>> GetAllForTeacher(string id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Groupe.Where(item => item.ProfesseurId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Groupe>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Groupe>>(null, 404, $"{typeof(Groupe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Groupe>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Groupe).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Groupe>>> GetAllGroupActif(string id)
        {
            try
            {

                var itemList = await sTIMULUSContext.Groupe.Where(item => item.ProfesseurId == id && item.DateCloture >= dateDuJour).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Groupe>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Groupe>>(null, 404, $"{typeof(Groupe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Groupe>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Groupe).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Groupe>>> GetAllById(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Groupe.Where(item => item.GroupeId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Groupe>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Groupe>>(null, 404, $"{typeof(Groupe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Groupe>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Groupe).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Groupe>> Update(int id, Groupe item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Groupe.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Groupe>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Groupe>(null, 404, $"{typeof(Groupe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Groupe>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Groupe).Name}. Message : {ex.Message}.");
            }
        }
    }
}
