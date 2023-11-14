using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;

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
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await groupeEtudiantService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await groupeEtudiantService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await groupeEtudiantService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await groupeEtudiantService.GetAllById(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All/GroupForStudent/{id}")]
        public async Task<IActionResult> GetAllGroupForStudent(string id)
        {
            var response = await groupeEtudiantService.GetAllGroupForStudent(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All/StudentForGroup/{id}")]
        public async Task<IActionResult> GetAllStudentForGroup(int id)
        {
            var response = await groupeEtudiantService.GetAllStudentForGroup(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Groupe_Etudiant groupeEtudiant)
        {
            var response = await groupeEtudiantService.Update(id, groupeEtudiant);
            return StatusCode(response.StatusCode, response);
        }
    }
}
