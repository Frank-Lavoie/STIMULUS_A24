using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class PageService : IPageService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public PageService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Page>> Create(Page item)
        {
            try
            {
                // Vérifier si l'importance existe déjà
                if (item.ImportanceId.HasValue)
                {
                    var existingImportance = await sTIMULUSContext.Importance.FindAsync(item.ImportanceId.Value);
                    if (existingImportance != null)
                    {
                        item.Importance = existingImportance;
                    }
                    else
                    {
                        // Si l'importance n'existe pas, vous pouvez choisir de lever une exception ou de créer une nouvelle importance par défaut.
                        // Dans cet exemple, nous allons créer une nouvelle importance par défaut.
                        item.Importance = new Importance { Code=1, Pts=1, Description="" };
                    }
                }

                sTIMULUSContext.Page.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Page.Contains(item))
                {
                    return new APIResponse<Page>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Page>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Page>(null, 500, $"Erreur lors de la création du modèle : {typeof(Page).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Page.Where(item => item.PageId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Page.FindAsync(id);
                    sTIMULUSContext.Page.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Page).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Page).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Page).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Page>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Page.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Page>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Page>(null, 404, $"{typeof(Page).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Page>(null, 500, $"Erreur lors de la récupération du model {typeof(Page).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Page>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Page.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Page>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Page>>(null, 404, $"{typeof(Page).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Page>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Page).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Page>>> GetAllById(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Page.Where(item => item.NoeudId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Page>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Page>>(null, 404, $"{typeof(Page).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Page>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Page).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Page>>> GetAllFromNoeud(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Page.Where(item => item.NoeudId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Page>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Page>>(null, 404, $"{typeof(Page).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Page>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Page).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Page>> Update(int id, Page item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Page.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Page>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Page>(null, 404, $"{typeof(Page).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Page>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Page).Name}. Message : {ex.Message}.");
            }
        }
    }
}
