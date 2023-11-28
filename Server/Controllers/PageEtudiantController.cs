using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

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

        [HttpGet("Calcule/{groupeId}/{codeDa}")]
        public async Task<IActionResult> CalculerPourcentage(int groupeId, string codeDa)
        {
            var response = await pageEtudiantService.CalculerPourcentage(groupeId, codeDa);
            return StatusCode(response.StatusCode, response);
        }
    }
}