using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoeudEtudiantController : Controller
    {
        private readonly INoeudEtudiantService noeudEtudiantService;

        public NoeudEtudiantController(INoeudEtudiantService noeudEtudiantService)
        {
            this.noeudEtudiantService = noeudEtudiantService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Noeud_Etudiant groupeEtudiant)
        {
            var response = await noeudEtudiantService.Create(groupeEtudiant);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await noeudEtudiantService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await noeudEtudiantService.Get(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("Fetch/Noeud/{id}")]
        public async Task<IActionResult> GetByNoeudId(int id)
        {
            var response = await noeudEtudiantService.GetByNoeudId(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("Fetch/NoeudAndDa/{id}/{da}")]
        public async Task<IActionResult> GetByNoeudAndDa(int id, string da)
        {
            var response = await noeudEtudiantService.GetByNoeudAndDa(id, da);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await noeudEtudiantService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await noeudEtudiantService.GetAllById(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("Fetch/All/NoeudForStudent/{id}")]
        public async Task<IActionResult> GetAllNoeudForStudent(string id)
        {
            var response = await noeudEtudiantService.GetAllNoeudForStudent(id);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Noeud_Etudiant noeudEtudiant)
        {
            var response = await noeudEtudiantService.Update(id, noeudEtudiant);
            return StatusCode(response.StatusCode, response);
        }
    }
}
