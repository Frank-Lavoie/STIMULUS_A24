using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

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
            var log = Log.ForContext<GrapheService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Graphe>>();
            log.Information($"Create(Graphe item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Graphe/Delete/{id}");
            var log = Log.ForContext<GrapheService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Graphe>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Graphe>>($"api/Graphe/Fetch/{id}");
            var log = Log.ForContext<GrapheService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }
        public async Task<APIResponse<Graphe>> GetGroupe(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Graphe>>($"api/Graphe/Fetch/Groupe/{id}");
            var log = Log.ForContext<GrapheService>();
            log.Information($"GetGroupe(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Graphe>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Graphe>>>("api/Graphe/Fetch/All");
            var log = Log.ForContext<GrapheService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public Task<APIResponse<IEnumerable<Graphe>>> GetAllById(int id)
        {
            var log = Log.ForContext<GrapheService>();
            var apiResponse = new NotImplementedException();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {apiResponse}");
            throw apiResponse;
        }

        public async Task<APIResponse<IEnumerable<Graphe>>> GetAllFromGroup(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Graphe>>>($"api/Graphe/Fetch/All/FromGroup/{id}");
            var log = Log.ForContext<GrapheService>();
            log.Information($"GetAllFromGroup(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<Graphe>> Update(int id, Graphe item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Graphe/Update/{id}", item);
            var log = Log.ForContext<GrapheService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Graphe>>();
            log.Information($"Update(int id = {id}, Graphe item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
