using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

namespace STIMULUS_V2.Client.Services
{
    public class ComposantService : IComposantService
    {
        private readonly HttpClient _httpClient;

        public ComposantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<Composant>> Create(Composant item)
        {
            var result = await _httpClient.PostAsJsonAsync<Composant>("api/Composant/Create", item);
            var log = Log.ForContext<ComposantService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Composant>>();
            log.Information($"Create(Composant item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Composant/Delete/{id}");
            var log = Log.ForContext<ComposantService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Composant>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Composant>>($"api/Composant/Fetch/{id}");
            var log = Log.ForContext<ComposantService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Composant>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Composant>>>("api/Composant/Fetch/All");
            var log = Log.ForContext<ComposantService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Composant>>> GetAllById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Composant>>>($"api/Composant/Fetch/All/{id}");
            var log = Log.ForContext<ComposantService>();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {result}");
            return result;
        }

		public async Task<APIResponse<IEnumerable<Composant>>> GetAllVideo(int id)
		{
			var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Composant>>>($"api/Composant/Fetch/AllVideo/{id}");
            var log = Log.ForContext<ComposantService>();
            log.Information($"GetAllVideo(int id = {id}) ApiResponse: {result}");
            return result;
		}

		public async Task<APIResponse<Composant>> Update(int id, Composant item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Composant/Update/{id}", item);
            var log = Log.ForContext<ComposantService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Composant>>();
            log.Information($"Update(int id = {id}, Composant item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
