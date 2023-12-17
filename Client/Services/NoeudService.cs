using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using Serilog;

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
            var log = Log.ForContext<NoeudService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Noeud>>();
            log.Information($"Create(Noeud item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Noeud/Delete/{id}");
            var log = Log.ForContext<NoeudService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Noeud>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Noeud>>($"api/Noeud/Fetch/{id}");
            var log = Log.ForContext<NoeudService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Noeud>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Noeud>>>("api/Noeud/Fetch/All");
            var log = Log.ForContext<NoeudService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Noeud>>> GetAllById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Noeud>>>($"api/Noeud/Fetch/AllBy/{id}");
            var log = Log.ForContext<NoeudService>();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Noeud>>> GetAllFromGraph(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Noeud>>>($"api/Noeud/Fetch/FromGraph/{id}");
            var log = Log.ForContext<NoeudService>();
            log.Information($"GetAllFromGraph(int id = {id}) ApiResponse: {result}");
            return result;
        }
        public async Task<APIResponse<bool>> ReOrderNoeuds(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<bool>>($"api/Noeud/Fetch/ReOrder/{id}");
            return result;
        }

        public async Task<APIResponse<Noeud>> Update(int id, Noeud item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Noeud/Update/{id}", item);
            var log = Log.ForContext<NoeudService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Noeud>>();
            log.Information($"Update(int id = {id}, Noeud item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
