using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

namespace STIMULUS_V2.Client.Services
{
    public class GroupeService : IGroupeService
    {
        private readonly HttpClient _httpClient;

        public GroupeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<Groupe>> Create(Groupe item)
        {
            var result = await _httpClient.PostAsJsonAsync<Groupe>("api/Groupe/Create", item);
            var log = Log.ForContext<GroupeService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Groupe>>();
            log.Information($"Create(Groupe item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Groupe/Delete/{id}");
            var log = Log.ForContext<GroupeService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Groupe>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Groupe>>($"api/Groupe/Fetch/{id}");
            var log = Log.ForContext<GroupeService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Groupe>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Groupe>>>("api/Groupe/Fetch/All");
            var log = Log.ForContext<GroupeService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Groupe>>> GetAllById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Groupe>>>($"api/Groupe/Fetch/All/{id}");
            var log = Log.ForContext<GroupeService>();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Groupe>>> GetAllForTeacher(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Groupe>>>($"api/Groupe/Fetch/All/ForTeacher/{id}");
            var log = Log.ForContext<GroupeService>();
            log.Information($"GetAllForTeacher(string id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Groupe>>> GetAllGroupActif(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Groupe>>>($"api/Groupe/Fetch/All/GroupActif/{id}");
            var log = Log.ForContext<GroupeService>();
            log.Information($"GetAllGroupActif(string id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<Groupe>> Update(int id, Groupe item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Groupe/Update/{id}", item);
            var log = Log.ForContext<GroupeService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Groupe>>();
            log.Information($"Update(int id = {id}, Groupe item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
