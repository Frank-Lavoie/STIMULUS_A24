using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using Serilog;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TexteFormaterController : Controller
    {
        private readonly ITexteFormaterService texteFormaterService;

        public TexteFormaterController(ITexteFormaterService texteFormaterService)
        {
            this.texteFormaterService = texteFormaterService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] TexteFormater texteFormater)
        {
            var response = await texteFormaterService.Create(texteFormater);
            var log = Log.ForContext<TexteFormaterController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] TexteFormater texteFormater = {texteFormater}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await texteFormaterService.Delete(id);
            var log = Log.ForContext<TexteFormaterController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await texteFormaterService.Get(id);
            var log = Log.ForContext<TexteFormaterController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await texteFormaterService.GetAll();
            var log = Log.ForContext<TexteFormaterController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await texteFormaterService.GetAllById(id);
            var log = Log.ForContext<TexteFormaterController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TexteFormater texteFormater)
        {
            var response = await texteFormaterService.Update(id, texteFormater);
            var log = Log.ForContext<TexteFormaterController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] TexteFormater texteFormater = {texteFormater}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
