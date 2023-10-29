using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LienUtileController : Controller
    {
        private readonly IModelService<LienUtile, int> lienUtileService;

        public LienUtileController(IModelService<LienUtile, int> lienUtileService)
        {
            this.lienUtileService = lienUtileService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] LienUtile lienUtile)
        {
            var response = await lienUtileService.Create(lienUtile);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await lienUtileService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await lienUtileService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await lienUtileService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/FromParent/{id}")]
        public async Task<IActionResult> GetFromParentId(int id)
        {
            var response = await lienUtileService.GetFromParentId(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LienUtile lienUtile)
        {
            var response = await lienUtileService.Update(id, lienUtile);
            return StatusCode(response.StatusCode, response);
        }
    }
}
