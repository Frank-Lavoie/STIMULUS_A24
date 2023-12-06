using Microsoft.AspNetCore.Mvc;
using Serilog;
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
            var log = Log.ForContext<GrapheController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Graphe graphe = {graphe}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await grapheService.Delete(id);
            var log = Log.ForContext<GrapheController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await grapheService.Get(id);
            var log = Log.ForContext<GrapheController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await grapheService.GetAll();
            var log = Log.ForContext<GrapheController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await grapheService.GetAllById(id);
            var log = Log.ForContext<GrapheController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/FromGroup/{id}")]
        public async Task<IActionResult> GetAllFromGroup(int id)
        {
            var response = await grapheService.GetAllFromGroup(id);
            var log = Log.ForContext<GrapheController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllFromGroup(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Graphe graphe)
        {
            var response = await grapheService.Update(id, graphe);
            var log = Log.ForContext<GrapheController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] Graphe graphe = {graphe}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
