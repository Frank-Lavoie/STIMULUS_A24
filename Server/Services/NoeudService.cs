using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class NoeudService : INoeudService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public NoeudService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Noeud>> Create(Noeud item)
        {
            try
            {
                sTIMULUSContext.Noeud.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Noeud.Contains(item))
                {
                    return new APIResponse<Noeud>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Noeud>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Noeud>(null, 500, $"Erreur lors de la création du model : {typeof(Noeud).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Noeud.Where(item => item.NoeudId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Noeud.FindAsync(id);
                    sTIMULUSContext.Noeud.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Noeud).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Noeud).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Noeud).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Noeud>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Noeud.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Noeud>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Noeud>(null, 404, $"{typeof(Noeud).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Noeud>(null, 500, $"Erreur lors de la récupération du model {typeof(Noeud).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Noeud>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Noeud.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Noeud>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Noeud>>(null, 404, $"{typeof(Noeud).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Noeud>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Noeud).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Noeud>>> GetAllById(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Noeud.Where(item => item.NoeudParentId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Noeud>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Noeud>>(null, 404, $"{typeof(Noeud).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Noeud>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Noeud).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Noeud>>> GetAllFromGraph(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Noeud.Where(item => item.GrapheId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Noeud>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Noeud>>(null, 404, $"{typeof(Noeud).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Noeud>>(null, 500, $"Erreur lors de la récupération du model par son graph {typeof(Noeud).Name}. Message : {ex.Message}.");
            }
        }
        public async Task<APIResponse<bool>> ReOrderNoeuds(int noeud)
        {
            try
            {
                var ParentNode = await Get(noeud);
                var ChildNode = await GetAllById(noeud);

                if(ParentNode.Data.Status == 0)
                {
                    ParentNode.Data.PosX = 805;
                    ParentNode.Data.PosY = -175;
                }

                // Ajustez la position en X et Y pour chaque enfant
                for (int i = 0; i < ChildNode.Data.Count(); i++)
                {
                    var ChildrenNode = ChildNode.Data.ElementAt(i);

                    // Ajustez la position en Y pour que les enfants soient sous le parent
                    ChildrenNode.PosY = ParentNode.Data.PosY + 400;

                    // Ajustez la position en X pour aligner les enfants horizontalement avec le parent
                    // et les espacer en fonction de l'index
                    ChildrenNode.PosX = ParentNode.Data.PosX + (i - (ChildNode.Data.Count() - 1) / 2.0) * 400;

                    await Update(ChildrenNode.NoeudId, ChildrenNode);
                }

                return new APIResponse<bool>(true, 200, "Ré-arrangement terminé");
            }
            catch
            {
                return new APIResponse<bool>(false, 500, "Erreur lors du ré-arrangement des noeuds");
            }

        }



        public async Task<APIResponse<Noeud>> Update(int id, Noeud item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Noeud.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Noeud>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Noeud>(null, 404, $"{typeof(Noeud).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Noeud>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Noeud).Name}. Message : {ex.Message}.");
            }
        }
    }
}
