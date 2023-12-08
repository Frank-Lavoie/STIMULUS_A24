using Microsoft.AspNetCore.Mvc;
using Serilog;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantController : Controller
    {
        private readonly IEtudiantService etudiantService;

        public EtudiantController(IEtudiantService etudiantService)
        {
            this.etudiantService = etudiantService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Etudiant etudiant)
        {
            var response = await etudiantService.Create(etudiant);
            var log = Log.ForContext<EtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Etudiant etudiant = {etudiant}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await etudiantService.Delete(id);
            var log = Log.ForContext<EtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(string id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await etudiantService.Get(id);
            var log = Log.ForContext<EtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(string id = {id}) \n  Response: {apiResponse}");
            return apiResponse; 
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await etudiantService.GetAll();
            var log = Log.ForContext<EtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        //[HttpGet("Fetch/All/{id}")]
        //public async Task<IActionResult> GetAllById(int id)
        //{
        //    var response = await etudiantService.GetAllById(id);
        //    return StatusCode(response.StatusCode, response);
        //}

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllByIdentifiant(string id)
        {
            var response = await etudiantService.GetAllByIdentifiant(id);
            var log = Log.ForContext<EtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllByIdentifiant(string id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Etudiant etudiant)
        {
            var response = await etudiantService.Update(id, etudiant);
            var log = Log.ForContext<EtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(string id = {id}, [FromBody] Etudiant etudiant = {etudiant}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
