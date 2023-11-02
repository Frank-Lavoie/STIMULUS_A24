using STIMULUS_V2.Client.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class ImportanceService : IModelService<Importance, int>
    {
        private readonly HttpClient _httpClient;

        public ImportanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<Importance>> Create(Importance item)
        {
            var result = await _httpClient.PostAsJsonAsync<Importance>("api/Importance/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Importance>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Importance/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Importance>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Importance>>($"api/Importance/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Importance>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Importance>>>("api/Importance/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<Importance>>> GetFromParentId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<Importance>> Update(int id, Importance item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Importance/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Importance>>();
        }
    }
}
