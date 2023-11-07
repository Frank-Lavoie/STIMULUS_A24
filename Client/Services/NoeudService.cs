using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class NoeudService : INoeudService
    {
        private readonly HttpClient _httpClient;

        public NoeudService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<Noeud>> Create(Noeud item)
        {
            var result = await _httpClient.PostAsJsonAsync<Noeud>("api/Noeud/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Noeud>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Noeud/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Noeud>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Noeud>>($"api/Noeud/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Noeud>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Noeud>>>("api/Noeud/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<Noeud>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<Noeud>> Update(int id, Noeud item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Noeud/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Noeud>>();
        }
    }
}
