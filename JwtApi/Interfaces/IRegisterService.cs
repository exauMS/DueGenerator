using JwtApi.Models;

namespace JwtApi.Interfaces
{
    public interface IRegisterService
    {
        UserInfo Register(string username, string email, string password, string role);
    }
}
