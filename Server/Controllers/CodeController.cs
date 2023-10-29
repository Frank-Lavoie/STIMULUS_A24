using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : Controller
    {
        private readonly IModelService<Code, int> codeService;

        public CodeController(IModelService<Code, int> codeService)
        {
            this.codeService = codeService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Code code)
        {
            var response = await codeService.Create(code);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await codeService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await codeService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await codeService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/FromParent/{id}")]
        public async Task<IActionResult> GetFromParentId(int id)
        {
            var response = await codeService.GetFromParentId(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Code code)
        {
            var response = await codeService.Update(id, code);
            return StatusCode(response.StatusCode, response);
        }        
    }
}
