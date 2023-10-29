using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusGrapheController : Controller
    {
        private readonly IModelService<StatusGraphe, int> statusGrapheService;

        public StatusGrapheController(IModelService<StatusGraphe, int> statusGrapheService)
        {
            this.statusGrapheService = statusGrapheService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] StatusGraphe statusGraphe)
        {
            var response = await statusGrapheService.Create(statusGraphe);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await statusGrapheService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await statusGrapheService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await statusGrapheService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/FromParent/{id}")]
        public async Task<IActionResult> GetFromParentId(int id)
        {
            var response = await statusGrapheService.GetFromParentId(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StatusGraphe statusGraphe)
        {
            var response = await statusGrapheService.Update(id, statusGraphe);
            return StatusCode(response.StatusCode, response);
        }
    }
}
