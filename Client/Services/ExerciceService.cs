using STIMULUS_V2.Client.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class ExerciceService : IModelService<Exercice, int>
    {
        private readonly HttpClient _httpClient;

        public ExerciceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<Exercice>> Create(Exercice item)
        {
            var result = await _httpClient.PostAsJsonAsync<Exercice>("api/Exercice/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Exercice>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Exercice/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Exercice>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Exercice>>($"api/Exercice/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Exercice>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Exercice>>>("api/Exercice/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<Exercice>>> GetFromParentId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<Exercice>> Update(int id, Exercice item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Exercice/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Exercice>>();
        }
    }
}
