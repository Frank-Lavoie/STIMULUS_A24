using STIMULUS_V2.Client.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class ImageService : IModelService<Image, int>
    {
        private readonly HttpClient _httpClient;

        public ImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<Image>> Create(Image item)
        {
            var result = await _httpClient.PostAsJsonAsync<Image>("api/Image/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Image>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Image/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Image>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Image>>($"api/Image/Fetch/{id}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Image>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Image>>>("api/Image/Fetch/All");
            return result;
        }

        public Task<APIResponse<IEnumerable<Image>>> GetFromParentId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<Image>> Update(int id, Image item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Image/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Image>>();
        }
    }
}
