using JwtApi.Interfaces;
using JwtApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtApi.Controllers
{
    
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService registerService;

        public RegisterController(IRegisterService registerService)
        {
            this.registerService = registerService;
        }

        [Authorize]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = registerService.Register(model.UserName, model.Email, model.Password,model.Role);
            
            if (user != null)
            {
                return Ok("User created!");
            }
            return BadRequest();

        }
    }
}
