using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichierSauvegardeController : Controller
    {
        private readonly IFichierSauvegardeService fichierSauvegardeService;

        public FichierSauvegardeController(IFichierSauvegardeService fichierSauvegardeService)
        {
            this.fichierSauvegardeService = fichierSauvegardeService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] FichierSauvegarde fichierSauvegarde)
        {
            var response = await fichierSauvegardeService.Create(fichierSauvegarde);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await fichierSauvegardeService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await fichierSauvegardeService.Get(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await fichierSauvegardeService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await fichierSauvegardeService.GetAllById(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FichierSauvegarde fichierSauvegarde)
        {
            var response = await fichierSauvegardeService.Update(id, fichierSauvegarde);
            return StatusCode(response.StatusCode, response);
        }
    }
}
