using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using DueWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DueWebAPI.Controllers
{
    [ApiController]
    public class AAController : Controller
    {
        private readonly IAA AAService;

        public AAController(IAA AAService) 
        {
            this.AAService = AAService;
        }


        [HttpGet("getAA/{id}")]
        public async Task<ActionResult<AA>> getAA(int id)
        {
            return await AAService.getAA(id);
        }
        [HttpGet("getAllAA")]
        public async Task<IEnumerable<AA>> GetAllAA()
        {
            return await AAService.GetAllAA();
        }

        [HttpPost("postAA")]
        public async Task<ActionResult<AA>> postAA(AA Aa)
        {
            var post = await AAService.postAA(Aa);
            return Ok(post);
        }

       
    }
}
