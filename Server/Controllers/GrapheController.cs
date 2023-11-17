using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrapheController : Controller
    {
        private readonly IGrapheService grapheService;

        public GrapheController(IGrapheService grapheService)
        {
            this.grapheService = grapheService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Graphe graphe)
        {
            var response = await grapheService.Create(graphe);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await grapheService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await grapheService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await grapheService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await grapheService.GetAllById(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All/FromGroup/{id}")]
        public async Task<IActionResult> GetAllFromGroup(int id)
        {
            var response = await grapheService.GetAllFromGroup(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Graphe graphe)
        {
            var response = await grapheService.Update(id, graphe);
            return StatusCode(response.StatusCode, response);
        }
    }
}
