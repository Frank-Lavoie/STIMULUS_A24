using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : Controller
    {
        private readonly IModelService<Video, int> videoService;

        public VideoController(IModelService<Video, int> videoService)
        {
            this.videoService = videoService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Video video)
        {
            var response = await videoService.Create(video);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await videoService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await videoService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await videoService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/FromParent/{id}")]
        public async Task<IActionResult> GetFromParentId(int id)
        {
            var response = await videoService.GetFromParentId(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Video video)
        {
            var response = await videoService.Update(id, video);
            return StatusCode(response.StatusCode, response);
        }
    }
}
