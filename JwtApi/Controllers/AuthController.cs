using JwtApi.Interfaces;
using JwtApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace JwtApi.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthService jwtAuthService;
        private readonly IConfiguration config;

        public AuthController(IJwtAuthService jwtAuthService, IConfiguration config)
        {
            this.jwtAuthService = jwtAuthService;
            this.config = config;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
           var user = this.jwtAuthService.Authenticate(model.Email, model.Password);
            if(user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                };
                var token = this.jwtAuthService.GenerateToken(this.config["Jwt:Key"], claims);
              
                return Ok(token);
            }
            else
            {
                Console.WriteLine("nuuullllllllll");
            }
            return Unauthorized();
            
        }
    }
}
