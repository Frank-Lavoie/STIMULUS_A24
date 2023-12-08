using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Interface.ParentInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

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
            return await result.Content.ReadFromJsonAsync<APIResponse<Noeud_Etudiant>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/NoeudEtudiant/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Noeud_Etudiant>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Noeud_Etudiant>>($"api/NoeudEtudiant/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<Noeud_Etudiant>> GetByNoeudId(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Noeud_Etudiant>>($"api/NoeudEtudiant/Fetch/Noeud/{id}");
            return result;
        }

        public async Task<APIResponse<Noeud_Etudiant>> GetByNoeudAndDa(int id, string da)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Noeud_Etudiant>>($"api/NoeudEtudiant/Fetch/NoeudAndDa/{id}/{da}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Noeud_Etudiant>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Noeud_Etudiant>>>("api/NoeudEtudiant/Fetch/All");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Noeud_Etudiant>>> GetAllById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Noeud_Etudiant>>>($"api/NoeudEtudiant/Fetch/All/{id}");
            return result; ;
        }
        public async Task<APIResponse<IEnumerable<Noeud_Etudiant>>> GetAllNoeudForStudent(string item)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Noeud_Etudiant>>>($"api/NoeudEtudiant/Fetch/All/NoeudForStudent/{item}");
            return result; ;
        }

        public async Task<APIResponse<Noeud_Etudiant>> Update(int id, Noeud_Etudiant item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/NoeudEtudiant/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Noeud_Etudiant>>();
        }
    }
}
