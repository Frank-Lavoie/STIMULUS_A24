using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

namespace STIMULUS_V2.Client.Services
{
    public class EtudiantService : IEtudiantService
    {
        private readonly HttpClient _httpClient;

        public EtudiantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<Etudiant>> Create(Etudiant item)
        {
            var result = await _httpClient.PostAsJsonAsync<Etudiant>("api/Etudiant/Create", item);
            var log = Log.ForContext<EtudiantService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Etudiant>>();
            log.Information($"Create(Etudiant item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync($"api/Etudiant/Delete/{id}");
            var log = Log.ForContext<EtudiantService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(string id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Etudiant>> Get(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Etudiant>>($"api/Etudiant/Fetch/{id}");
            var log = Log.ForContext<EtudiantService>();
            log.Information($"Get(string id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Etudiant>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Etudiant>>>("api/Etudiant/Fetch/All");
            var log = Log.ForContext<EtudiantService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Etudiant>>> GetAllById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Etudiant>>>($"api/Etudiant/Fetch/All/{id}");
            var log = Log.ForContext<EtudiantService>();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Etudiant>>> GetAllByIdentifiant(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Etudiant>>>($"api/Etudiant/Fetch/All/{id}");
            var log = Log.ForContext<EtudiantService>();
            log.Information($"GetAllByIdentifiant(string id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<Etudiant>> Update(string id, Etudiant item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Etudiant/Update/{id}", item);
            var log = Log.ForContext<EtudiantService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Etudiant>>();
            log.Information($"Update(string id = {id}, Etudiant item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
