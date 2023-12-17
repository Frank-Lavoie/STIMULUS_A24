using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Interface.ParentInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

namespace STIMULUS_V2.Client.Services
{
    public class NoeudEtudiantService : INoeudEtudiantService
    {
        private readonly HttpClient _httpClient;

        public NoeudEtudiantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<Noeud_Etudiant>> Create(Noeud_Etudiant item)
        {
            var result = await _httpClient.PostAsJsonAsync<Noeud_Etudiant>("api/NoeudEtudiant/Create", item);
            var log = Log.ForContext<NoeudEtudiantService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Noeud_Etudiant>>();
            log.Information($"Create(Noeud_Etudiant item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/NoeudEtudiant/Delete/{id}");
            var log = Log.ForContext<NoeudEtudiantService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Noeud_Etudiant>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Noeud_Etudiant>>($"api/NoeudEtudiant/Fetch/{id}");
            var log = Log.ForContext<NoeudEtudiantService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<Noeud_Etudiant>> GetByNoeudId(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Noeud_Etudiant>>($"api/NoeudEtudiant/Fetch/Noeud/{id}");
            var log = Log.ForContext<NoeudEtudiantService>();
            log.Information($"GetByNoeudId(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<Noeud_Etudiant>> GetByNoeudAndDa(int id, string da)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Noeud_Etudiant>>($"api/NoeudEtudiant/Fetch/NoeudAndDa/{id}/{da}");
            var log = Log.ForContext<NoeudEtudiantService>();
            log.Information($"GetByNoeudAndDa(int id = {id}, string da = {da}) ApiResponse: {result}");
            return result;
        }
        public async Task<APIResponse<bool>> GetProgression(string da, int graphe, int noeud)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<bool>>($"api/NoeudEtudiant/Fetch/Progression/{da}/{graphe}/{noeud}");
            var log = Log.ForContext<NoeudEtudiantService>();
            log.Information($"GetProgression(string da = {da}, int graphe = {graphe}, int noeud = {noeud}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Noeud_Etudiant>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Noeud_Etudiant>>>("api/NoeudEtudiant/Fetch/All");
            var log = Log.ForContext<NoeudEtudiantService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Noeud_Etudiant>>> GetAllById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Noeud_Etudiant>>>($"api/NoeudEtudiant/Fetch/All/{id}");
            var log = Log.ForContext<NoeudEtudiantService>();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {result}");
            return result; ;
        }
        public async Task<APIResponse<IEnumerable<Noeud_Etudiant>>> GetAllNoeudForStudent(string item)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Noeud_Etudiant>>>($"api/NoeudEtudiant/Fetch/All/NoeudForStudent/{item}");
            var log = Log.ForContext<NoeudEtudiantService>();
            log.Information($"GetAllNoeudForStudent(string item = {item}) ApiResponse: {result}");
            return result; ;
        }

        public async Task<APIResponse<Noeud_Etudiant>> Update(int id, Noeud_Etudiant item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/NoeudEtudiant/Update/{id}", item);
            var log = Log.ForContext<NoeudEtudiantService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Noeud_Etudiant>>();
            log.Information($"Update(int id = {id}, Noeud_Etudiant item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
