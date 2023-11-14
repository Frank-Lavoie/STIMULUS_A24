using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupeController : Controller
    {
        private readonly IGroupeService groupeService;

        public GroupeController(IGroupeService groupeService)
        {
            this.groupeService = groupeService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Groupe groupe)
        {
            var response = await groupeService.Create(groupe);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await groupeService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await groupeService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await groupeService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await groupeService.GetAllById(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All/ForTeacher/{id}")]
        public async Task<IActionResult> GetAllForTeacher(string id)
        {
            var response = await groupeService.GetAllForTeacher(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Groupe groupe)
        {
            var response = await groupeService.Update(id, groupe);
            return StatusCode(response.StatusCode, response);
        }
    }
}
