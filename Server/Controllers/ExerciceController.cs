using Microsoft.AspNetCore.Mvc;
using Serilog;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciceController : Controller
    {
        private readonly IExerciceService exerciceService;

        public ExerciceController(IExerciceService exerciceService)
        {
            this.exerciceService = exerciceService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Exercice exercice)
        {
            var response = await exerciceService.Create(exercice);
            var log = Log.ForContext<EtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Exercice exercice = {exercice}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPost("Execute/{da}/{json}")]
        public async Task<IActionResult> ExecuteCode(string da, string json)
        {
            var response = await exerciceService.ExecuteCode(da, json);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await exerciceService.Delete(id);
            var log = Log.ForContext<EtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await exerciceService.Get(id);
            var log = Log.ForContext<EtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await exerciceService.GetAll();
            var log = Log.ForContext<EtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await exerciceService.GetAllById(id);
            var log = Log.ForContext<EtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Exercice exercice)
        {
            var response = await exerciceService.Update(id, exercice);
            var log = Log.ForContext<EtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] Exercice exercice = {exercice}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
