using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

namespace STIMULUS_V2.Client.Services
{
    public class CodeService : ICodeService
    {
        private readonly HttpClient _httpClient;

        public CodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<Code>> Create(Code item)
        {
            var result = await _httpClient.PostAsJsonAsync<Code>("api/Code/Create", item);
            var log = Log.ForContext<CodeService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Code>>();
            log.Information($"Create(Code item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {

            var result = await _httpClient.DeleteAsync($"api/Code/Delete/{id}");
            var log = Log.ForContext<CodeService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Code>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Code>>($"api/Code/Fetch/{id}");
            var log = Log.ForContext<CodeService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Code>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Code>>>("api/Code/Fetch/All");
            var log = Log.ForContext<CodeService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public Task<APIResponse<IEnumerable<Code>>> GetAllById(int id)
        {
            var log = Log.ForContext<CodeService>();
            var apiResponse = new NotImplementedException();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {apiResponse}");
            throw apiResponse;
        }

        public async Task<APIResponse<Code>> Update(int id, Code item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Code/Update/{id}", item);
            var log = Log.ForContext<CodeService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Code>>();
            log.Information($"Update(int id = {id}, Code item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
