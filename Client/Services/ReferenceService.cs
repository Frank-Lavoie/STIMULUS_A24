using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class ReferenceService : IReferenceService
    {
        private readonly HttpClient _httpClient;

        public ReferenceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<Reference>> Create(Reference item)
        {
            var result = await _httpClient.PostAsJsonAsync<Reference>("api/Reference/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Reference>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Reference/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Reference>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Reference>>($"api/Reference/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Reference>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Reference>>>("api/Reference/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<Reference>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<Reference>> Update(int id, Reference item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Reference/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Reference>>();
        }
    }
}
