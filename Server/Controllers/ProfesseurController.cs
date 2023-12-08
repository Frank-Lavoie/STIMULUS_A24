using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using Serilog;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesseurController : Controller
    {
        private readonly IProfesseurService professeurService;

        public ProfesseurController(IProfesseurService professeurService)
        {
            this.professeurService = professeurService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Professeur professeur)
        {
            var response = await professeurService.Create(professeur);
            var log = Log.ForContext<ProfesseurController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Professeur professeur = {professeur}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await professeurService.Delete(id);
            var log = Log.ForContext<ProfesseurController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(string id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await professeurService.Get(id);
            var log = Log.ForContext<ProfesseurController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(string id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await professeurService.GetAll();
            var log = Log.ForContext<ProfesseurController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await professeurService.GetAllById(id);
            var log = Log.ForContext<ProfesseurController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Professeur professeur)
        {
            var response = await professeurService.Update(id, professeur);
            var log = Log.ForContext<ProfesseurController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(string id = {id}, [FromBody] Professeur professeur = {professeur}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
