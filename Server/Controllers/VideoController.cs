using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using Serilog;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : Controller
    {
        private readonly IVideoService videoService;

        public VideoController(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Video video)
        {
            var response = await videoService.Create(video);
            var log = Log.ForContext<VideoController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Video video = {video}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await videoService.Delete(id);
            var log = Log.ForContext<VideoController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await videoService.Get(id);
            var log = Log.ForContext<VideoController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await videoService.GetAll();
            var log = Log.ForContext<VideoController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await videoService.GetAllById(id);
            var log = Log.ForContext<VideoController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Video video)
        {
            var response = await videoService.Update(id, video);
            var log = Log.ForContext<VideoController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] Video video = {video}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
