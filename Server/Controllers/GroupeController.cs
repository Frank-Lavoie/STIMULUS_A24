using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using Serilog;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupeController : Controller
    {
        private readonly IGroupeService groupeService;

        public GroupeController(IGroupeService groupeService)
        {
            this.groupeService = groupeService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Groupe groupe)
        {
            var response = await groupeService.Create(groupe);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Groupe groupe = {groupe}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await groupeService.Delete(id);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await groupeService.Get(id);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await groupeService.GetAll();
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await groupeService.GetAllById(id);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/ForTeacher/{id}")]
        public async Task<IActionResult> GetAllForTeacher(string id)
        {
            var response = await groupeService.GetAllForTeacher(id);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllForTeacher(string id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/GroupActif/{id}")]
        public async Task<IActionResult> GetAllActif(string id)
        {
            var response = await groupeService.GetAllGroupActif(id);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllActif(string id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Groupe groupe)
        {
            var response = await groupeService.Update(id, groupe);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] Groupe groupe = {groupe}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
