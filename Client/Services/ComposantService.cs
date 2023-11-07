using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class ComposantService : IComposantService
    {
        private readonly HttpClient _httpClient;

        public ComposantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<Composant>> Create(Composant item)
        {
            var result = await _httpClient.PostAsJsonAsync<Composant>("api/Composant/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Composant>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Composant/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Composant>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Composant>>($"api/Composant/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Composant>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Composant>>>("api/Composant/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<Composant>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<Composant>> Update(int id, Composant item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Composant/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Composant>>();
        }
    }
}
