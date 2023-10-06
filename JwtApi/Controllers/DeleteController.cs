using JwtApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
   
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly IDeleteService deleteService;

        public DeleteController(IDeleteService deleteService)
        {
            this.deleteService = deleteService;
        }

        [Authorize]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = deleteService.delete(id);

            if (response != null)
            {
                
                return Ok(response);
            }
            return NotFound();
        }
    }
}
