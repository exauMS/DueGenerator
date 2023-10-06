using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using DueWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DueWebAPI.Controllers
{
    [ApiController]
    public class CursusController : Controller
    {
        private readonly ICursus cursusService;

        public CursusController(ICursus cursusService)
        {
            this.cursusService = cursusService;
        }


        [HttpGet("getCursus/{id}")]
        public async Task<ActionResult<Cursus>> getCursus(int id)
        {
            return await cursusService.getCursus(id);
        }
        [HttpGet("getAllCursus")]
        public async Task<IEnumerable<Cursus>> GetAllCursus()
        {
            return await cursusService.GetAllCursus();
        }

        [HttpPost("postCursus")]
        public async Task<ActionResult<string>> PostCursus(Cursus cursus)
        {
            var post = await cursusService.postCursus(cursus);

            return Ok(post);
           
        }

    }
}
