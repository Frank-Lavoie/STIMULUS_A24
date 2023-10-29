using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciceController : Controller
    {
        private readonly IModelService<Exercice, int> exerciceService;

        public ExerciceController(IModelService<Exercice, int> exerciceService)
        {
            this.exerciceService = exerciceService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Exercice exercice)
        {
            var response = await exerciceService.Create(exercice);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await exerciceService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await exerciceService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await exerciceService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/FromParent/{id}")]
        public async Task<IActionResult> GetFromParentId(int id)
        {
            var response = await exerciceService.GetFromParentId(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Exercice exercice)
        {
            var response = await exerciceService.Update(id, exercice);
            return StatusCode(response.StatusCode, response);
        }
    }
}
