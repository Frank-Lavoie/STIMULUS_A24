using STIMULUS_V2.Shared.Models.DTOs;

namespace STIMULUS_V2.Server.Services.Interfaces
{
    public interface IModelService<T, TKey>
    {
        Task<APIResponse<T>> Create(T item);

        Task<APIResponse<T>> Get(TKey id);

        Task<APIResponse<IEnumerable<T>>> GetAll();

        Task<APIResponse<IEnumerable<T>>> GetFromParentId(int id);

        Task<APIResponse<T>> Update(TKey id, T item);

        Task<APIResponse<bool>> Delete(TKey id);
    }
}
