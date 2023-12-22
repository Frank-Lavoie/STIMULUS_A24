using STIMULUS_V2.Shared.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Interface.ParentInterface
{
    public interface IModelService<T, TKey>
    {
        Task<APIResponse<T>> Create(T item);

        Task<APIResponse<T>> Get(TKey id);

        Task<APIResponse<IEnumerable<T>>> GetAll();

        Task<APIResponse<IEnumerable<T>>> GetAllById(int id);

        Task<APIResponse<T>> Update(TKey id, T item);

        Task<APIResponse<bool>> Delete(TKey id);
    }
}
