using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

namespace STIMULUS_V2.Client.Services
{
    public class PageService : IPageService
    {
        private readonly HttpClient _httpClient;

        public PageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<Page>> Create(Page item)
        {
            var result = await _httpClient.PostAsJsonAsync<Page>("api/Page/Create", item);
            var log = Log.ForContext<PageService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Page>>();
            log.Information($"Create(Page item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Page/Delete/{id}");
            var log = Log.ForContext<PageService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Page>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Page>>($"api/Page/Fetch/{id}");
            var log = Log.ForContext<PageService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Page>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Page>>>("api/Page/Fetch/All");
            var log = Log.ForContext<PageService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Page>>> GetAllById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Page>>>($"api/Page/Fetch/AllBy/{id}");
            var log = Log.ForContext<PageService>();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Page>>> GetAllFromNoeud(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Page>>>($"api/Page/Fetch/All/FromNoeud/{id}");
            var log = Log.ForContext<PageService>();
            log.Information($"GetAllFromNoeud(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<Page>> Update(int id, Page item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Page/Update/{id}", item);
            var log = Log.ForContext<PageService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Page>>();
            log.Information($"Update(int id = {id}, Page item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
