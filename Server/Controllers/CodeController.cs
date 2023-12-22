using Microsoft.AspNetCore.Mvc;
using Serilog;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Authentication;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : Controller
    {
        private readonly ICodeService codeService;

        public CodeController(ICodeService codeService)
        {
            this.codeService = codeService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Code code)
        {
            var response = await codeService.Create(code);
            var log = Log.ForContext<CodeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Code code = {code}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await codeService.Delete(id);
            var log = Log.ForContext<CodeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await codeService.Get(id);
            var log = Log.ForContext<CodeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await codeService.GetAll();
            var log = Log.ForContext<CodeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await codeService.GetAllById(id);
            var log = Log.ForContext<CodeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Code code)
        {
            var response = await codeService.Update(id, code);
            var log = Log.ForContext<CodeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id, [FromBody] Code code = {code}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
