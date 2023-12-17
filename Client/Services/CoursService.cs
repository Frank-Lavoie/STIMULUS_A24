using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

namespace STIMULUS_V2.Client.Services
{
    public class CoursService : ICoursService
    {
        private readonly HttpClient _httpClient;

        public CoursService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<Cours>> Create(Cours item)
        {
            var result = await _httpClient.PostAsJsonAsync<Cours>("api/Cours/Create", item);
            var log = Log.ForContext<CoursService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Cours>>();
            log.Information($"Create(Cours item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Cours/Delete/{id}");
            var log = Log.ForContext<CoursService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Cours>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Cours>>($"api/Cours/Fetch/{id}");
            var log = Log.ForContext<CoursService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Cours>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Cours>>>("api/Cours/Fetch/All");
            var log = Log.ForContext<CoursService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Cours>>> GetAllById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Cours>>>($"api/Cours/Fetch/All/{id}");
            var log = Log.ForContext<CoursService>();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<Cours>> Update(int id, Cours item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Cours/Update/{id}", item);
            var log = Log.ForContext<CoursService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Cours>>();
            log.Information($"Update(int id = {id}, Cours item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
