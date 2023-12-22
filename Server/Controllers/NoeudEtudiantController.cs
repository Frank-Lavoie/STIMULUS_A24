using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using Serilog;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoeudEtudiantController : Controller
    {
        private readonly INoeudEtudiantService noeudEtudiantService;

        public NoeudEtudiantController(INoeudEtudiantService noeudEtudiantService)
        {
            this.noeudEtudiantService = noeudEtudiantService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Noeud_Etudiant groupeEtudiant)
        {
            var response = await noeudEtudiantService.Create(groupeEtudiant);
            var log = Log.ForContext<NoeudEtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Noeud_Etudiant groupeEtudiant = {groupeEtudiant}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await noeudEtudiantService.Delete(id);
            var log = Log.ForContext<NoeudEtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await noeudEtudiantService.Get(id);
            var log = Log.ForContext<NoeudEtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }
        [HttpGet("Fetch/Noeud/{id}")]
        public async Task<IActionResult> GetByNoeudId(int id)
        {
            var response = await noeudEtudiantService.GetByNoeudId(id); 
            var log = Log.ForContext<NoeudEtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetByNoeudId(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }
        [HttpGet("Fetch/NoeudAndDa/{id}/{da}")]
        public async Task<IActionResult> GetByNoeudAndDa(int id, string da)
        {
            var response = await noeudEtudiantService.GetByNoeudAndDa(id, da); 
            var log = Log.ForContext<NoeudEtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetByNoeudAndDa(int id = {id}, string da = {da}) \n  Response: {apiResponse}");
            return apiResponse;
        }
        [HttpGet("Fetch/Progression/{da}/{graphe}/{noeud}")]
        public async Task<IActionResult> GetProgression(string da, int graphe, int noeud)
        {
            var response = await noeudEtudiantService.GetProgression(da, graphe, noeud); 
            var log = Log.ForContext<NoeudEtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetProgression(string da = {da}, int graphe = {graphe}, int noeud = {noeud}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await noeudEtudiantService.GetAll(); 
            var log = Log.ForContext<NoeudEtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await noeudEtudiantService.GetAllById(id);
            var log = Log.ForContext<NoeudEtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"> GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }
        [HttpGet("Fetch/All/NoeudForStudent/{id}")]
        public async Task<IActionResult> GetAllNoeudForStudent(string id)
        {
            var response = await noeudEtudiantService.GetAllNoeudForStudent(id);
            var log = Log.ForContext<NoeudEtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllNoeudForStudent(string id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Noeud_Etudiant noeudEtudiant)
        {
            var response = await noeudEtudiantService.Update(id, noeudEtudiant);
            var log = Log.ForContext<NoeudEtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] Noeud_Etudiant noeudEtudiant = {noeudEtudiant}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
