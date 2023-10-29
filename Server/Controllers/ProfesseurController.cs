using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesseurController : Controller
    {
        private readonly IModelService<Professeur, int> professeurService;

        public ProfesseurController(IModelService<Professeur, int> professeurService)
        {
            this.professeurService = professeurService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Professeur professeur)
        {
            var response = await professeurService.Create(professeur);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await professeurService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await professeurService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await professeurService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/FromParent/{id}")]
        public async Task<IActionResult> GetFromParentId(int id)
        {
            var response = await professeurService.GetFromParentId(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Professeur professeur)
        {
            var response = await professeurService.Update(id, professeur);
            return StatusCode(response.StatusCode, response);
        }
    }
}
