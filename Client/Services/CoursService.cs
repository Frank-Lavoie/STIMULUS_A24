using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class CoursService : ICoursService
    {
        private readonly HttpClient _httpClient;

        public CoursService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<Cours>> Create(Cours item)
        {
            var result = await _httpClient.PostAsJsonAsync<Cours>("api/Cours/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Cours>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Cours/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Cours>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Cours>>($"api/Cours/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Cours>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Cours>>>("api/Cours/Fetch/All");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Cours>>> GetAllById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Cours>>>($"api/Cours/Fetch/All/{id}");
            return result;
        }

        public async Task<APIResponse<Cours>> Update(int id, Cours item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Cours/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Cours>>();
        }
    }
}
