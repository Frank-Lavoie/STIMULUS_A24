using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class PageEtudiantService : IPageEtudiantService
    {
        private readonly HttpClient _httpClient;

        public PageEtudiantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponse<double>> CalculerPourcentage(int groupeId, string codeDa, string professeurIdentifiant)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<double>>($"api/PageEtudiant/Calcule/{groupeId}/{codeDa}/{professeurIdentifiant}");
            return result;
        }
    }
}