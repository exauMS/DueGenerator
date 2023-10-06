using JwtApi.Models;
using System.Security.Claims;

namespace JwtApi.Interfaces
{
    public interface IJwtAuthService
    {
        UserInfo Authenticate(string email, string password);
        string GenerateToken(string secret, List<Claim> claims);
    }
}
