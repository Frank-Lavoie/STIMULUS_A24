using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using Serilog;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportanceController : Controller
    {
        private readonly IImportanceService importanceService;

        public ImportanceController(IImportanceService importanceService)
        {
            this.importanceService = importanceService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Importance importance)
        {
            var response = await importanceService.Create(importance);
            var log = Log.ForContext<ImportanceController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Importance importance = {importance}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await importanceService.Delete(id);
            var log = Log.ForContext<ImportanceController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await importanceService.Get(id);
            var log = Log.ForContext<ImportanceController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await importanceService.GetAll();
            var log = Log.ForContext<ImportanceController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await importanceService.GetAllById(id);
            var log = Log.ForContext<ImportanceController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Importance importance)
        {
            var response = await importanceService.Update(id, importance);
            var log = Log.ForContext<ImportanceController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] Importance importance = {importance}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
