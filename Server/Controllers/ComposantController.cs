using Microsoft.AspNetCore.Mvc;
using Serilog;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using System.ComponentModel;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComposantController : Controller
    {
        private readonly IComposantService composantService;

        public ComposantController(IComposantService composantService)
        {
            this.composantService = composantService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Composant composant)
        {
            var response = await composantService.Create(composant);
            var log = Log.ForContext<ComposantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Composant composant = {composant}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await composantService.Delete(id);
            var log = Log.ForContext<ComposantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($" Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await composantService.Get(id);
            var log = Log.ForContext<ComposantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await composantService.GetAll();
            var log = Log.ForContext<ComposantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await composantService.GetAllById(id);
            var log = Log.ForContext<ComposantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/AllVideo/{id}")]
        public async Task<IActionResult> GetAllVideo(int id)
        {
            var response = await composantService.GetAllVideo(id);
            var log = Log.ForContext<ComposantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllVideo(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Composant composant)
        {
            var response = await composantService.Update(id, composant);
            var log = Log.ForContext<ComposantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] Composant composant = {composant}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
