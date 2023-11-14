using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

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
            return await result.Content.ReadFromJsonAsync<APIResponse<Etudiant>>();
        }

        public async Task<APIResponse<bool>> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync($"api/Etudiant/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Etudiant>> Get(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Etudiant>>($"api/Etudiant/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Etudiant>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Etudiant>>>("api/Etudiant/Fetch/All");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Etudiant>>> GetAllById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Etudiant>>>($"api/Etudiant/Fetch/All/{id}");
            return result;
        }
        public async Task<APIResponse<IEnumerable<Etudiant>>> GetAllByIdentifiant(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Etudiant>>>($"api/Etudiant/Fetch/All/{id}");
            return result;
        }

        public async Task<APIResponse<Etudiant>> Update(string id, Etudiant item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Etudiant/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Etudiant>>();
        }
    }
}
