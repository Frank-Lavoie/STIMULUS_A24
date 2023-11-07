using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class TexteFormaterService : ITexteFormaterService
    {
        private readonly HttpClient _httpClient;

        public TexteFormaterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<TexteFormater>> Create(TexteFormater item)
        {
            var result = await _httpClient.PostAsJsonAsync<TexteFormater>("api/TexteFormater/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<TexteFormater>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/TexteFormater/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<TexteFormater>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<TexteFormater>>($"api/TexteFormater/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<TexteFormater>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<TexteFormater>>>("api/TexteFormater/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<TexteFormater>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<TexteFormater>> Update(int id, TexteFormater item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/TexteFormater/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<TexteFormater>>();
        }
    }
}
