using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantController : Controller
    {
        private readonly IEtudiantService etudiantService;

        public EtudiantController(IEtudiantService etudiantService)
        {
            this.etudiantService = etudiantService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Etudiant etudiant)
        {
            var response = await etudiantService.Create(etudiant);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await etudiantService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await etudiantService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await etudiantService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await etudiantService.GetAllById(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllByIdentifiant(string id)
        {
            var response = await etudiantService.GetAllByIdentifiant(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Etudiant etudiant)
        {
            var response = await etudiantService.Update(id, etudiant);
            return StatusCode(response.StatusCode, response);
        }
    }
}
