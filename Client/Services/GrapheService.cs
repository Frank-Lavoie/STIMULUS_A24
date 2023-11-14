using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class GrapheService : IGrapheService
    {
        private readonly HttpClient _httpClient;

        public GrapheService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<Graphe>> Create(Graphe item)
        {
            var result = await _httpClient.PostAsJsonAsync<Graphe>("api/Graphe/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Graphe>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Graphe/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Graphe>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Graphe>>($"api/Graphe/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Graphe>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Graphe>>>("api/Graphe/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<Graphe>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<APIResponse<IEnumerable<Graphe>>> GetAllFromGroup(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Graphe>>>($"api/Graphe/Fetch/All/FromGroup/{id}");
            return result; ;
        }

        public async Task<APIResponse<Graphe>> Update(int id, Graphe item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Graphe/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Graphe>>();
        }
    }
}
