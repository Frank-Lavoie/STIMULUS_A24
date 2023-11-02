using STIMULUS_V2.Client.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class FichierSourceService : IModelService<FichierSource, int>
    {
        private readonly HttpClient _httpClient;

        public FichierSourceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<FichierSource>> Create(FichierSource item)
        {
            var result = await _httpClient.PostAsJsonAsync<FichierSource>("api/FichierSource/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<FichierSource>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/FichierSource/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<FichierSource>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<FichierSource>>($"api/FichierSource/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<FichierSource>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<FichierSource>>>("api/FichierSource/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<FichierSource>>> GetFromParentId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<FichierSource>> Update(int id, FichierSource item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/FichierSource/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<FichierSource>>();
        }
    }
}
