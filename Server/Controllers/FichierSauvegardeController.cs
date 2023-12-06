using Microsoft.AspNetCore.Mvc;
using Serilog;
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
            var log = Log.ForContext<FichierSauvegardeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Create([FromBody] FichierSauvegarde fichierSauvegarde = {fichierSauvegarde}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await fichierSauvegardeService.Delete(id);
            var log = Log.ForContext<FichierSauvegardeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Delete(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await fichierSauvegardeService.Get(id);
            var log = Log.ForContext<FichierSauvegardeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Get(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await fichierSauvegardeService.GetAll();
            var log = Log.ForContext<FichierSauvegardeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAll() \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpGet("Fetch/All/{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var response = await fichierSauvegardeService.GetAllById(id);
            var log = Log.ForContext<FichierSauvegardeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"GetAllById(int id = {id}) \n  Response: {apiResponse}");
            return apiResponse;
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FichierSauvegarde fichierSauvegarde)
        {
            var response = await fichierSauvegardeService.Update(id, fichierSauvegarde);
            var log = Log.ForContext<FichierSauvegardeController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"Update(int id = {id}, [FromBody] FichierSauvegarde fichierSauvegarde = {fichierSauvegarde}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}
