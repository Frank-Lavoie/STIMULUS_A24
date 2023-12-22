using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

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
            var log = Log.ForContext<VideoService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Video>>();
            log.Information($"Create(Video item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Video/Delete/{id}");
            var log = Log.ForContext<VideoService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Video>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Video>>($"api/Video/Fetch/{id}");
            var log = Log.ForContext<VideoService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }      

        public async Task<APIResponse<IEnumerable<Video>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Video>>>("api/Video/Fetch/All");
            var log = Log.ForContext<VideoService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Video>>> GetAllById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Video>>>($"api/Video/Fetch/All{id}");
            var log = Log.ForContext<VideoService>();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<Video>> Update(int id, Video item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Video/Update/{id}", item);
            var log = Log.ForContext<VideoService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Video>>();
            log.Information($"Update(int id = {id}, Video item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
