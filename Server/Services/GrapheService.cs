using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Linq;

namespace STIMULUS_V2.Server.Services
{
    public class GrapheService : IGrapheService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public GrapheService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Graphe>> Create(Graphe item)
        {
            try
            {
                sTIMULUSContext.Graphe.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Graphe.Contains(item))
                {
                    return new APIResponse<Graphe>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Graphe>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Graphe>(null, 500, $"Erreur lors de la création du model : {typeof(Graphe).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Graphe.Where(item => item.GrapheId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Graphe.FindAsync(id);
                    sTIMULUSContext.Graphe.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Graphe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Graphe).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Graphe).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Graphe>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Graphe.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Graphe>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Graphe>(null, 404, $"{typeof(Graphe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Graphe>(null, 500, $"Erreur lors de la récupération du model {typeof(Graphe).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Graphe>> GetGroupe(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Graphe.Where(item => item.GroupeId == id).FirstOrDefaultAsync();

                if (item != null)
                {
                    return new APIResponse<Graphe>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Graphe>(null, 404, $"{typeof(Graphe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Graphe>(null, 500, $"Erreur lors de la récupération du model {typeof(Graphe).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Graphe>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Graphe.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Graphe>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Graphe>>(null, 404, $"{typeof(Graphe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Graphe>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Graphe).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Graphe>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<IEnumerable<Graphe>>> GetAllFromGroup(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Graphe.Where(item => item.GroupeId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Graphe>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Graphe>>(null, 404, $"{typeof(Graphe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Graphe>>(null, 500, $"Erreur lors de la récupération du model par son graph {typeof(Graphe).Name}. Message : {ex.Message}.");
            }
        }        

        public async Task<APIResponse<Graphe>> Update(int id, Graphe item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Graphe.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Graphe>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Graphe>(null, 404, $"{typeof(Graphe).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Graphe>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Graphe).Name}. Message : {ex.Message}.");
            }
        }
    }
}
