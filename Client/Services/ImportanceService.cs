using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog; 

namespace STIMULUS_V2.Client.Services
{
    public class ImportanceService : IImportanceService
    {
        private readonly HttpClient _httpClient;

        public ImportanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<Importance>> Create(Importance item)
        {
            var result = await _httpClient.PostAsJsonAsync<Importance>("api/Importance/Create", item);
            var log = Log.ForContext<ImportanceService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Importance>>();
            log.Information($"Create(Importance item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Importance/Delete/{id}");
            var log = Log.ForContext<ImportanceService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Importance>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Importance>>($"api/Importance/Fetch/{id}");
            var log = Log.ForContext<ImportanceService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Importance>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Importance>>>("api/Importance/Fetch/All");
            var log = Log.ForContext<ImportanceService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public Task<APIResponse<IEnumerable<Importance>>> GetAllById(int id)
        {
            var log = Log.ForContext<ImportanceService>();
            var apiResponse = new NotImplementedException();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {apiResponse}");
            throw apiResponse;
        }

        public async Task<APIResponse<Importance>> Update(int id, Importance item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Importance/Update/{id}", item);
            var log = Log.ForContext<ImportanceService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Importance>>();
            log.Information($"Update(int id = {id}, Importance item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
