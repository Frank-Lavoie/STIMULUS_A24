using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class CodeService : ICodeService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public CodeService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<Code>> Create(Code item)
        {
            try
            {
                sTIMULUSContext.Code.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.Code.Contains(item))
                {
                    return new APIResponse<Code>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Code>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Code>(null, 500, $"Erreur lors de la création du model : {typeof(Code).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.Code.Where(item => item.CodeId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.Code.FindAsync(id);
                    sTIMULUSContext.Code.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(Code).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Code).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(Code).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<Code>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.Code.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<Code>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Code>(null, 404, $"{typeof(Code).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Code>(null, 500, $"Erreur lors de la récupération du model {typeof(Code).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Code>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.Code.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Code>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Code>>(null, 404, $"{typeof(Code).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Code>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(Code).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<Code>>> GetAllById(int id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Code.Where(item => item.CodeId == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Code>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Code>>(null, 404, $"{typeof(Code).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Code>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Code).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<Code>> Update(int id, Code item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.Code.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<Code>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<Code>(null, 404, $"{typeof(Code).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Code>(null, 500, $"Erreur lors de la mise à jour du model {typeof(Code).Name}. Message : {ex.Message}.");
            }
        }
    }
}
