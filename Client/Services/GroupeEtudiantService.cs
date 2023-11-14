using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class GroupeEtudiantService : IGroupeEtudiantService
    {
        private readonly HttpClient _httpClient;

        public GroupeEtudiantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<Groupe_Etudiant>> Create(Groupe_Etudiant item)
        {
            var result = await _httpClient.PostAsJsonAsync<Groupe_Etudiant>("api/GroupeEtudiant/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Groupe_Etudiant>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/GroupeEtudiant/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Groupe_Etudiant>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Groupe_Etudiant>>($"api/GroupeEtudiant/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Groupe_Etudiant>>>("api/GroupeEtudiant/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAllGroupForStudent(string item)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Groupe_Etudiant>>>($"api/GroupeEtudiant/Fetch/All/GroupForStudent/{item}");
            return result; ;
        }
        public async Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAllStudentForGroup(int item)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Groupe_Etudiant>>>($"api/GroupeEtudiant/Fetch/All/StudentForGroup/{item}");
            return result; ;
        }
        public async Task<APIResponse<Groupe_Etudiant>> Update(int id, Groupe_Etudiant item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/GroupeEtudiant/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Groupe_Etudiant>>();
        }
    }
}
