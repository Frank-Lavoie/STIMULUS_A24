using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

namespace STIMULUS_V2.Client.Services
{
    public class FichierSourceService : IFichierSourceService
    {
        private readonly HttpClient _httpClient;

        public FichierSourceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<FichierSource>> Create(FichierSource item)
        {
            var result = await _httpClient.PostAsJsonAsync<FichierSource>("api/FichierSource/Create", item);
            var log = Log.ForContext<FichierSourceService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<FichierSource>>();
            log.Information($"Create(FichierSource item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/FichierSource/Delete/{id}");
            var log = Log.ForContext<FichierSourceService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<FichierSource>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<FichierSource>>($"api/FichierSource/Fetch/{id}");
            var log = Log.ForContext<FichierSourceService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<FichierSource>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<FichierSource>>>("api/FichierSource/Fetch/All");
            var log = Log.ForContext<FichierSourceService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public Task<APIResponse<IEnumerable<FichierSource>>> GetAllById(int id)
        {
            var log = Log.ForContext<FichierSourceService>();
            var apiResponse = new NotImplementedException();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {apiResponse}");
            throw apiResponse;
        }

        public async Task<APIResponse<FichierSource>> Update(int id, FichierSource item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/FichierSource/Update/{id}", item);
            var log = Log.ForContext<FichierSourceService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<FichierSource>>();
            log.Information($"Update(int id = {id}, FichierSource item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
