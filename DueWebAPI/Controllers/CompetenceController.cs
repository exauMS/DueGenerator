using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using DueWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DueWebAPI.Controllers
{
    [ApiController]
    public class CompetenceController : Controller
    {
        private readonly ICompetence competenceService;

        public CompetenceController(ICompetence competenceService)
        {
            this.competenceService = competenceService;
        }

        [HttpGet("getCompetence/{id}")]
        public async Task<ActionResult<Competence>> getCompetence(int id)
        {
            return await competenceService.getCompetence(id);
        }
        [HttpGet("getAllCompetence")]
        public async Task<IEnumerable<Competence>> GetAllCompetence()
        {
            return await competenceService.GetAllCompetence();
        }

        [HttpPost("postCompetence")]
        public async Task<ActionResult<Competence>> postCompetence(Competence competence)
        {
           
            var post = await competenceService.postCompetence(competence);
            return Ok(post);
           
        }

      
    }
}
