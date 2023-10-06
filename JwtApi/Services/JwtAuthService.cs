using JwtApi.Interfaces;
using JwtApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace JwtApi.Services
{
    public class JwtAuthService : IJwtAuthService
    {
        //ici on récupère le user au niveau de la db
        private List<UserInfo> users;
        private readonly DataContext context;
        public JwtAuthService(DataContext context)
        {
            this.context = context;
        }


        public UserInfo Authenticate(string email, string password)
        {
            users = context.UserInfos.ToList();
            return users.FirstOrDefault(u => u.Email.ToLower().Equals(email.ToLower()) && u.Password.Equals(password));
        }

        public string GenerateToken(string secret, List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
