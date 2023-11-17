using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class GroupeEtudiantService : IGroupeEtudiantService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public GroupeEtudiantService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }
        public async Task<APIResponse<Groupe_Etudiant>> Create(Groupe_Etudiant item)
        {
            try
            {
                sTIMULUSContext.Groupe_Etudiant.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Groupe_Etudiant.Contains(item))
                {
                    return new APIResponse<Groupe_Etudiant>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Groupe_Etudiant>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Groupe_Etudiant>(null, 500, $"Erreur lors de la création du model : {typeof(Groupe_Etudiant).Name}. Message : {ex.Message}");
            }
        }        

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Groupe_Etudiant.Where(item => item.Groupe_EtudiantId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Groupe_Etudiant.FindAsync(id);
                    sTIMULUSContext.Groupe_Etudiant.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Groupe_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Groupe_Etudiant).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Groupe_Etudiant).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Groupe_Etudiant>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Groupe_Etudiant.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Groupe_Etudiant>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Groupe_Etudiant>(null, 404, $"{typeof(Groupe_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Groupe_Etudiant>(null, 500, $"Erreur lors de la récupération du model {typeof(Groupe_Etudiant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Groupe_Etudiant.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Groupe_Etudiant>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Groupe_Etudiant>>(null, 404, $"{typeof(Groupe_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Groupe_Etudiant>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Groupe_Etudiant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAllGroupForStudent(string id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Groupe_Etudiant.Where(item => item.Etudiant.Identifiant == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Groupe_Etudiant>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Groupe_Etudiant>>(null, 404, $"{typeof(Groupe_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Groupe_Etudiant>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Groupe_Etudiant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAllStudentForGroup(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Groupe_Etudiant.Where(item => item.GroupeId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Groupe_Etudiant>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Groupe_Etudiant>>(null, 404, $"{typeof(Groupe_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Groupe_Etudiant>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Groupe_Etudiant).Name}. Message : {ex.Message}.");
            }
        }
        public async Task<APIResponse<Groupe_Etudiant>> Update(int id, Groupe_Etudiant item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Groupe_Etudiant.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Groupe_Etudiant>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Groupe_Etudiant>(null, 404, $"{typeof(Groupe_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Groupe_Etudiant>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Groupe_Etudiant).Name}. Message : {ex.Message}.");
            }
        }
    }
}
