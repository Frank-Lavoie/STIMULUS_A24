using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

namespace STIMULUS_V2.Client.Services
{
    public class TexteFormaterService : ITexteFormaterService
    {
        private readonly HttpClient _httpClient;

        public TexteFormaterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<TexteFormater>> Create(TexteFormater item)
        {
            var result = await _httpClient.PostAsJsonAsync<TexteFormater>("api/TexteFormater/Create", item);
            var log = Log.ForContext<TexteFormaterService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<TexteFormater>>();
            log.Information($"Create(TexteFormater item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/TexteFormater/Delete/{id}");
            var log = Log.ForContext<TexteFormaterService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<TexteFormater>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<TexteFormater>>($"api/TexteFormater/Fetch/{id}");
            var log = Log.ForContext<TexteFormaterService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<TexteFormater>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<TexteFormater>>>("api/TexteFormater/Fetch/All");
            var log = Log.ForContext<TexteFormaterService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public Task<APIResponse<IEnumerable<TexteFormater>>> GetAllById(int id)
        {
            var log = Log.ForContext<TexteFormaterService>();
            var apiResponse = new NotImplementedException();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {apiResponse}");
            throw apiResponse;
        }

        public async Task<APIResponse<TexteFormater>> Update(int id, TexteFormater item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/TexteFormater/Update/{id}", item);
            var log = Log.ForContext<TexteFormaterService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<TexteFormater>>();
            log.Information($"Update(int id = {id}, TexteFormater item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
