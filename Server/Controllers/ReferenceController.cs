using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using Serilog;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceController : Controller
    {
        private readonly IReferenceService referenceService;

        public ReferenceController(IReferenceService referenceService)
        {
            this.referenceService = referenceService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Reference reference)
        {
            var response = await referenceService.Create(reference);
            var log = Log.ForContext<ProfesseurController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Reference reference = {reference}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await referenceService.Delete(id);
            var log = Log.ForContext<ProfesseurController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await referenceService.Get(id);
            var log = Log.ForContext<ProfesseurController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await referenceService.GetAll();
            var log = Log.ForContext<ProfesseurController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await referenceService.GetAllById(id);
            var log = Log.ForContext<ProfesseurController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Reference reference)
        {
            var response = await referenceService.Update(id, reference);
            var log = Log.ForContext<ProfesseurController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] Reference reference = {reference}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
