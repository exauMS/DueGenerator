using DueWebApp.Dto;
using DueWebApp.Models;

namespace DueWebApp.Interfaces
{
    public interface IUser
    {
        public Task<string?> GetToken(Login login);
        public Task<List<User>?> GetUsers(string token);
        public Task<string> PostUser(UserDto user, string token);
        public Task<string> DeleteUser(int id, string token);



    }
}
