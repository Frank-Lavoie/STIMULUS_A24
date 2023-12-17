using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

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
            var log = Log.ForContext<ReferenceService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Reference>>();
            log.Information($"Create(Reference item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Reference/Delete/{id}");
            var log = Log.ForContext<ReferenceService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Reference>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Reference>>($"api/Reference/Fetch/{id}");
            var log = Log.ForContext<ReferenceService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Reference>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Reference>>>("api/Reference/Fetch/All");
            var log = Log.ForContext<ReferenceService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public Task<APIResponse<IEnumerable<Reference>>> GetAllById(int id)
        {
            var log = Log.ForContext<ReferenceService>();
            var apiResponse = new NotImplementedException();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {apiResponse}");
            throw apiResponse;
        }

        public async Task<APIResponse<Reference>> Update(int id, Reference item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Reference/Update/{id}", item);
            var log = Log.ForContext<ReferenceService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Reference>>();
            log.Information($"Update(int id = {id}, Reference item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
