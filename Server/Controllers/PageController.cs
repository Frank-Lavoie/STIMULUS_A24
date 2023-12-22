using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using Serilog;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : Controller
    {
        private readonly IPageService pageService;

        public PageController(IPageService pageService)
        {
            this.pageService = pageService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Page page)
        {
            var response = await pageService.Create(page);
            var log = Log.ForContext<PageController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Page page = {page}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await pageService.Delete(id);
            var log = Log.ForContext<PageController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await pageService.Get(id);
            var log = Log.ForContext<PageController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await pageService.GetAll();
            var log = Log.ForContext<PageController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await pageService.GetAllById(id);
            var log = Log.ForContext<PageController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/FromNoeud/{id}")]
        public async Task<IActionResult> GetAllFromNoeud(int id)
        {
            var response = await pageService.GetAllFromNoeud(id);
            var log = Log.ForContext<PageController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllFromNoeud(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Page page)
        {
            var response = await pageService.Update(id, page);
            var log = Log.ForContext<PageController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] Page page = {page}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
