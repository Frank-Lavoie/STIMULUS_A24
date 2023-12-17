using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;
using Serilog;

namespace STIMULUS_V2.Client.Services
{
    public class ImageService : IImageService
    {
        private readonly HttpClient _httpClient;

        public ImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<Image>> Create(Image item)
        {
            var result = await _httpClient.PostAsJsonAsync<Image>("api/Image/Create", item);
            var log = Log.ForContext<ImageService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Image>>();
            log.Information($"Create(Image item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Image/Delete/{id}");
            var log = Log.ForContext<ImageService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<bool>>();
            log.Information($"Delete(int id = {id}) ApiResponse: {apiResponse}");
            return apiResponse;
        }

        public async Task<APIResponse<Image>> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<Image>>($"api/Image/Fetch/{id}");
            var log = Log.ForContext<ImageService>();
            log.Information($"Get(int id = {id}) ApiResponse: {result}");
            return result;
        }

        public async Task<APIResponse<IEnumerable<Image>>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Image>>>("api/Image/Fetch/All");
            var log = Log.ForContext<ImageService>();
            log.Information($"GetAll() ApiResponse: {result}");
            return result;
        }

        public Task<APIResponse<IEnumerable<Image>>> GetAllById(int id)
        {
            var log = Log.ForContext<ImageService>();
            var apiResponse = new NotImplementedException();
            log.Information($"GetAllById(int id = {id}) ApiResponse: {apiResponse}");
            throw apiResponse;
        }

        public async Task<APIResponse<Image>> Update(int id, Image item)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Image/Update/{id}", item);
            var log = Log.ForContext<ImageService>();
            var apiResponse = await result.Content.ReadFromJsonAsync<APIResponse<Image>>();
            log.Information($"Update(int id = {id}, Image item = {item}) ApiResponse: {apiResponse}");
            return apiResponse;
        }
    }
}
