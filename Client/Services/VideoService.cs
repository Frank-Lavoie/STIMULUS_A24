using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class VideoService : IVideoService
    {
        private readonly HttpClient _httpClient;

        public VideoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<Video>> Create(Video item)
        {
            var result = await _httpClient.PostAsJsonAsync<Video>("api/Video/Create", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Video>>();
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Video/Delete/{id}");
            return await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
        }

        public async Task<APIResponse<Video>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Video>>($"api/Video/Fetch/{id}");
            return result;
        }      

        public async Task<APIResponse<IEnumerable<Video>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Video>>>("api/Video/Fetch/All");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Video>>> GetAllById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Video>>>($"api/Video/Fetch/All{id}");
            return result;
        }

        public async Task<APIResponse<Video>> Update(int id, Video item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Video/Update/{id}", item);
            return await result.Content.ReadFromJsonAsync<APIResponse<Video>>();
        }
    }
}
