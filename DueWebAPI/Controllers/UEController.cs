using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using DueWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DueWebAPI.Controllers
{
    [ApiController]
    public class UEController : Controller
    {
        private readonly IUE UEService;

        public UEController(IUE UEService)
        {
            this.UEService = UEService;
        }

        [HttpGet("getUE/{id}")]
        public async Task<ActionResult<UE>> getUE(int id)
        {
            return await UEService.getUE(id);
        }

        [HttpGet("getAllUE")]
        public async Task<IEnumerable<UE>> GetAllUE()
        {
            return await UEService.GetAllUE();
        }

        [HttpPost("postUE")]
        public async Task<ActionResult<string>> postUE(UE UE)
        {
            var post = await UEService.postUE(UE);
            return Ok(post);
        }

        
    }
}
