using STIMULUS_V2.Client.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class FichierSauvegardeService : IModelService<FichierSauvegarde, int>
    {
        private readonly HttpClient _httpClient;

        public FichierSauvegardeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<FichierSauvegarde>> Create(FichierSauvegarde item)
        {
            var result = await _httpClient.PostAsJsonAsync<FichierSauvegarde>("api/FichierSauvegarde/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<FichierSauvegarde>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/FichierSauvegarde/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<FichierSauvegarde>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<FichierSauvegarde>>($"api/FichierSauvegarde/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<FichierSauvegarde>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<FichierSauvegarde>>>("api/FichierSauvegarde/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<FichierSauvegarde>>> GetFromParentId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<FichierSauvegarde>> Update(int id, FichierSauvegarde item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/FichierSauvegarde/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<FichierSauvegarde>>();
        }
    }
}
