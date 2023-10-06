using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DueWebAPI.Controllers
{
    [ApiController]
    public class FicheController : Controller
    {
        private readonly IFiche ficheService;

        public FicheController(IFiche ficheService)
        {
            this.ficheService = ficheService;
        }

        [HttpGet("getFiche/{id}")]
        public async Task<ActionResult<Fiche>> getFiche(int id)
        {
            return await ficheService.getFiche(id);
        }
        [HttpGet("getAllFiche")]
        public async Task<IEnumerable<Fiche>> GetAllFiche()
        {
            return await ficheService.GetAllFiche();
        }

        [HttpPost("postFiche")]
        public async Task<ActionResult<Fiche>> postFiche([FromBody] Fiche fiche)
        {
           
            var post = await ficheService.postFiche(fiche);
            return Ok(post);
          
        }

    }
}
