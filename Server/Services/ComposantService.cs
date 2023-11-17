using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Linq;

namespace STIMULUS_V2.Server.Services
{
    public class ComposantService : IComposantService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public ComposantService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Composant>> Create(Composant item)
        {
            try
            {
                sTIMULUSContext.Composant.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Composant.Contains(item))
                {
                    return new APIResponse<Composant>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Composant>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Composant>(null, 500, $"Erreur lors de la création du model : {typeof(Composant).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Composant.Where(item => item.ComposantId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Composant.FindAsync(id);
                    sTIMULUSContext.Composant.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Composant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Composant).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Composant).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Composant>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Composant.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Composant>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Composant>(null, 404, $"{typeof(Composant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Composant>(null, 500, $"Erreur lors de la récupération du model {typeof(Composant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Composant>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Composant.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Composant>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Composant>>(null, 404, $"{typeof(Composant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Composant>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Composant).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Composant>>> GetAllById(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Composant.Where(item => item.PageId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Composant>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Composant>>(null, 404, $"{typeof(Composant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Composant>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Composant).Name}. Message : {ex.Message}.");
            }
        }

		public async Task<APIResponse<IEnumerable<Composant>>> GetAllVideo(int id)
		{
			try
			{
				var itemList = await sTIMULUSContext.Composant.Where(item => item.ComposantId == id && item.Type == "Video").ToListAsync();

				if (itemList != null)
				{
					return new APIResponse<IEnumerable<Composant>>(itemList, 200, "Succès");
				}
				else
				{
					return new APIResponse<IEnumerable<Composant>>(null, 404, $"{typeof(Composant).Name} non trouvé");
				}
			}
			catch (Exception ex)
			{
				return new APIResponse<IEnumerable<Composant>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Composant).Name}. Message : {ex.Message}.");
			}
		}

		public async Task<APIResponse<Composant>> Update(int id, Composant item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Composant.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Composant>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Composant>(null, 404, $"{typeof(Composant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Composant>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Composant).Name}. Message : {ex.Message}.");
            }
        }
    }
}
