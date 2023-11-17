using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using System.ComponentModel;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComposantController : Controller
    {
        private readonly IComposantService composantService;

        public ComposantController(IComposantService composantService)
        {
            this.composantService = composantService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Composant composant)
        {
            var response = await composantService.Create(composant);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await composantService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await composantService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await composantService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await composantService.GetAllById(id);
            return StatusCode(response.StatusCode, response);
        }
		[HttpGet("Fetch/AllVideo/{id}")]
		public async Task<IActionResult> GetAllVideo(int id)
		{
			var response = await composantService.GetAllVideo(id);
			return StatusCode(response.StatusCode, response);
		}

		[HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Composant composant)
        {
            var response = await composantService.Update(id, composant);
            return StatusCode(response.StatusCode, response);
        }
    }
}
