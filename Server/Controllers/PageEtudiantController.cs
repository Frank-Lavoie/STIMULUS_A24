using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using Serilog;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageEtudiantController : Controller
    {
        private readonly IPageEtudiantService pageEtudiantService;

        public PageEtudiantController(IPageEtudiantService pageEtudiantService)
        {
            this.pageEtudiantService = pageEtudiantService;
        }

        [HttpGet("Calcule/{groupeId}/{codeDa}/{professeurIdentifiant}")]
        public async Task<IActionResult> CalculerPourcentage(int groupeId, string codeDa, string professeurIdentifiant)
        {
            var response = await pageEtudiantService.CalculerPourcentage(groupeId, codeDa, professeurIdentifiant);
            var log = Log.ForContext<PageEtudiantController>();
            var apiResponse = StatusCode(response.StatusCode, response);
            log.Information($"CalculerPourcentage(int groupeId = {groupeId}, string codeDa = {codeDa}, string professeurIdentifiant = {professeurIdentifiant}) \n  Response: {apiResponse}");
            return apiResponse;
        }
    }
}