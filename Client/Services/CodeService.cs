using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class CodeService : ICodeService
    {
        private readonly HttpClient _httpClient;

        public CodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<Code>> Create(Code item)
        {
            var result = await _httpClient.PostAsJsonAsync<Code>("api/Code/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Code>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Code/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Code>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Code>>($"api/Code/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Code>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Code>>>("api/Code/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<Code>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<Code>> Update(int id, Code item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Code/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Code>>();
        }
    }
}
