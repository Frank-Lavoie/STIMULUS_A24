using Microsoft.AspNetCore.Mvc;
using Serilog;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichierSourceController : Controller
    {
        private readonly IFichierSourceService fichierSourceService;

        public FichierSourceController(IFichierSourceService fichierSourceService)
        {
            this.fichierSourceService = fichierSourceService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] FichierSource fichierSource)
        {
            var response = await fichierSourceService.Create(fichierSource);
            var log = Log.ForContext<FichierSourceController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] FichierSource fichierSource = {fichierSource}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await fichierSourceService.Delete(id);
            var log = Log.ForContext<FichierSourceController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await fichierSourceService.Get(id);
            var log = Log.ForContext<FichierSourceController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await fichierSourceService.GetAll();
            var log = Log.ForContext<FichierSourceController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await fichierSourceService.GetAllById(id);
            var log = Log.ForContext<FichierSourceController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FichierSource fichierSource)
        {
            var response = await fichierSourceService.Update(id, fichierSource);
            var log = Log.ForContext<FichierSourceController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] FichierSource fichierSource = {fichierSource}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
