using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using Serilog;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoeudController : Controller
    {
        private readonly INoeudService noeudService;

        public NoeudController(INoeudService noeudService)
        {
            this.noeudService = noeudService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Noeud noeud)
        {
            var response = await noeudService.Create(noeud);
            var log = Log.ForContext<NoeudController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Noeud noeud = {noeud}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await noeudService.Delete(id);
            var log = Log.ForContext<NoeudController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await noeudService.Get(id);
            var log = Log.ForContext<NoeudController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await noeudService.GetAll();
            var log = Log.ForContext<NoeudController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await noeudService.GetAllById(id);
            var log = Log.ForContext<NoeudController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/FromGraph/{id}")]
        public async Task<IActionResult> GetAllFromGraph(int id)
        {
            var response = await noeudService.GetAllFromGraph(id);
            var log = Log.ForContext<NoeudController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllFromGraph(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/ReOrder/{id}")]
        public async Task<IActionResult> ReOrderNoeuds(int id)
        {
            var response = await noeudService.ReOrderNoeuds(id);
            var log = Log.ForContext<NoeudController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllFromGraph(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Noeud noeud)
        {
            var response = await noeudService.Update(id, noeud);
            var log = Log.ForContext<NoeudController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] Noeud noeud = {noeud}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
