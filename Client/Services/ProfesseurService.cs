using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

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
            return await result.Content.ReadFromJsonAsync<APIResponse<Professeur>>();
        }

        public async Task<APIResponse<bool>> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync($"api/Professeur/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Professeur>> Get(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Professeur>>($"api/Professeur/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Professeur>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Professeur>>>("api/Professeur/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<Professeur>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<Professeur>> Update(string id, Professeur item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Professeur/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Professeur>>();
        }
    }
}
