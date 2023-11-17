using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursController : Controller
    {
        private readonly ICoursService coursService;

        public CoursController(ICoursService coursService)
        {
            this.coursService = coursService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Cours cours)
        {
            var response = await coursService.Create(cours);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await coursService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await coursService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await coursService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await coursService.GetAllById(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cours cours)
        {
            var response = await coursService.Update(id, cours);
            return StatusCode(response.StatusCode, response);
        }
    }
}
