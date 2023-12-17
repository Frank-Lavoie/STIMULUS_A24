using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog; 

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
            var log = Log.ForContext<GroupeEtudiantService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Groupe_Etudiant>>();
            log.Information($"Create(Groupe_Etudiant item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/GroupeEtudiant/Delete/{id}");
            var log = Log.ForContext<GroupeEtudiantService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Groupe_Etudiant>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Groupe_Etudiant>>($"api/GroupeEtudiant/Fetch/{id}");
            var log = Log.ForContext<GroupeEtudiantService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Groupe_Etudiant>>>("api/GroupeEtudiant/Fetch/All");
            var log = Log.ForContext<GroupeEtudiantService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAllById(int id)
        {
            var log = Log.ForContext<GroupeEtudiantService>();
            var apiResponse = new NotImplementedException();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {apiResponse}");
            throw apiResponse;
        }

        public async Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAllGroupForStudent(string item)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Groupe_Etudiant>>>($"api/GroupeEtudiant/Fetch/All/GroupForStudent/{item}");
            var log = Log.ForContext<GroupeEtudiantService>();
            log.Information($"GetAllGroupForStudent(string item = {item}) ApiResponse: {result}");
            return result; ;
        }

        public async Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAllStudentForGroup(int item)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Groupe_Etudiant>>>($"api/GroupeEtudiant/Fetch/All/StudentForGroup/{item}");
            var log = Log.ForContext<GroupeEtudiantService>();
            log.Information($"GetAllStudentForGroup(int item = {item}) ApiResponse: {result}");
            return result; ;
        }

        public async Task<APIResponse<Groupe_Etudiant>> Update(int id, Groupe_Etudiant item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/GroupeEtudiant/Update/{id}", item);
            var log = Log.ForContext<GroupeEtudiantService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Groupe_Etudiant>>();
            log.Information($"Update(int id = {id}, Groupe_Etudiant item = {item}) ApiResponse: {result}");
            return apiResponse;
        }
    }
}
