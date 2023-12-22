using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

namespace STIMULUS_V2.Client.Services
{
    public class ProfesseurService : IProfesseurService
    {
        private readonly HttpClient _httpClient;

        public ProfesseurService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<Professeur>> Create(Professeur item)
        {
            var result = await _httpClient.PostAsJsonAsync<Professeur>("api/Professeur/Create", item);
            var log = Log.ForContext<ProfesseurService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Professeur>>();
            log.Information($"Create(Professeur item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync($"api/Professeur/Delete/{id}");
            var log = Log.ForContext<ProfesseurService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(string id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Professeur>> Get(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Professeur>>($"api/Professeur/Fetch/{id}");
            var log = Log.ForContext<ProfesseurService>();
            log.Information($"Get(string id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Professeur>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Professeur>>>("api/Professeur/Fetch/All");
            var log = Log.ForContext<ProfesseurService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public Task<APIResponse<IEnumerable<Professeur>>> GetAllById(int id)
        {
            var log = Log.ForContext<ProfesseurService>();
            var apiResponse = new NotImplementedException();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {apiResponse}");
            throw apiResponse;
        }

        public async Task<APIResponse<Professeur>> Update(string id, Professeur item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Professeur/Update/{id}", item);
            var log = Log.ForContext<ProfesseurService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Professeur>>();
            log.Information($"Update(string id = {id}, Professeur item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
