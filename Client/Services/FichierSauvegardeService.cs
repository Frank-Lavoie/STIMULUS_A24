using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

namespace STIMULUS_V2.Client.Services
{
    public class FichierSauvegardeService : IFichierSauvegardeService
    {
        private readonly HttpClient _httpClient;

        public FichierSauvegardeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<FichierSauvegarde>> Create(FichierSauvegarde item)
        {
            var result = await _httpClient.PostAsJsonAsync<FichierSauvegarde>("api/FichierSauvegarde/Create", item);
            var log = Log.ForContext<FichierSauvegardeService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<FichierSauvegarde>>();
            log.Information($"Create(FichierSauvegarde item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/FichierSauvegarde/Delete/{id}");
            var log = Log.ForContext<FichierSauvegardeService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<FichierSauvegarde>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<FichierSauvegarde>>($"api/FichierSauvegarde/Fetch/{id}");
            var log = Log.ForContext<FichierSauvegardeService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<FichierSauvegarde>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<FichierSauvegarde>>>("api/FichierSauvegarde/Fetch/All");
            var log = Log.ForContext<FichierSauvegardeService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }
        public async Task<APIResponse<IEnumerable<FichierSauvegarde>>> GetAllExercice(int exerciceId, string da)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<FichierSauvegarde>>>($"api/FichierSauvegarde/Fetch/All/Exercice/{da}/{exerciceId}");
            var log = Log.ForContext<FichierSauvegardeService>();
            log.Information($"GetAllExercice(int exerciceId = {exerciceId}, string da = {da}) ApiResponse: {result}");
            return result;
        }
        public Task<APIResponse<IEnumerable<FichierSauvegarde>>> GetAllById(int id)
        {
            var log = Log.ForContext<FichierSauvegardeService>();
            var apiResponse = new NotImplementedException();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {apiResponse}");
            throw apiResponse;
        }

        public async Task<APIResponse<FichierSauvegarde>> Update(int id, FichierSauvegarde item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/FichierSauvegarde/Update/{id}", item);
            var log = Log.ForContext<FichierSauvegardeService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<FichierSauvegarde>>();
            log.Information($"Update(int id = {id}, FichierSauvegarde item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
