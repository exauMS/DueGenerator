using DueWebAPI.Interfaces;
using DueWebAPI.Models;
using DueWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DueWebAPI.Controllers
{
    [ApiController]
    public class DepartementController : Controller
    {
        private readonly IDepartement departementService;

        public DepartementController(IDepartement departementService)
        {
            this.departementService = departementService;
        }

        [HttpGet("getDepartement/{id}")]
        public async Task<ActionResult<Departement>> getDepartement(int id)
        {
            return await departementService.getDepartement(id);
        }
       
        [HttpGet("getAllDepartement")]
        public async Task<IEnumerable<Departement>> GetAllDepartement()
        {
            return await departementService.GetAllDepartement();
        }
       
        [HttpPost("postDepartement")]
        public async Task<ActionResult<string>> PostDepartement(Departement departement)
        {
            
            var post = await departementService.postDepartement(departement);
            return Ok(post);
            
        }

       
    }
}
