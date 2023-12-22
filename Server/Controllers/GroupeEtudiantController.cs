using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;
using Serilog;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupeEtudiantController : Controller
    {
        private readonly IGroupeEtudiantService groupeEtudiantService;

        public GroupeEtudiantController(IGroupeEtudiantService groupeEtudiantService)
        {
            this.groupeEtudiantService = groupeEtudiantService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Groupe_Etudiant groupeEtudiant)
        {
            var response = await groupeEtudiantService.Create(groupeEtudiant);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] Groupe_Etudiant groupeEtudiant = {groupeEtudiant}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await groupeEtudiantService.Delete(id);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await groupeEtudiantService.Get(id);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await groupeEtudiantService.GetAll();
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await groupeEtudiantService.GetAllById(id);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/GroupForStudent/{id}")]
        public async Task<IActionResult> GetAllGroupForStudent(string id)
        {
            var response = await groupeEtudiantService.GetAllGroupForStudent(id);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllGroupForStudent(string id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/StudentForGroup/{id}")]
        public async Task<IActionResult> GetAllStudentForGroup(int id)
        {
            var response = await groupeEtudiantService.GetAllStudentForGroup(id);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllStudentForGroup(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Groupe_Etudiant groupeEtudiant)
        {
            var response = await groupeEtudiantService.Update(id, groupeEtudiant);
            var log = Log.ForContext<GroupeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] Groupe_Etudiant groupeEtudiant = {groupeEtudiant}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
