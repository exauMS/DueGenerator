using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using DueWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DueWebAPI.Controllers
{
    [ApiController]
    public class CapaciteController : Controller
    {
        private readonly ICapacite capaciteService;

        public CapaciteController(ICapacite capaciteService)
        {
            this.capaciteService = capaciteService;
        }


        [HttpGet("getCapacite/{id}")]
        public async Task<ActionResult<Capacite>> getCapacite(int id)
        {
            return await capaciteService.getCapacite(id);
        }

        [HttpGet("getAllCapacite")]
        public async Task<IEnumerable<Capacite>> GetAllCapacite()
        {
            return await capaciteService.GetAllCapacite();
        }

        [HttpPost("postCapacite")]
        public async Task<ActionResult<Capacite>> postCapacite(Capacite capacite)
        {
           
            var post = await capaciteService.postCapacite(capacite);
            return Ok(post);
           
          
        }

    }
}
