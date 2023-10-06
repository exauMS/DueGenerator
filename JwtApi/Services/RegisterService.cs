using JwtApi.Interfaces;
using JwtApi.Models;

namespace JwtApi.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly DataContext context;

        public RegisterService(DataContext context)
        {
            this.context = context;
        }
     
        public UserInfo Register(string username, string email, string password, string role)
        {
            UserInfo user = new()
            {
                UserName=username,
                Email=email,
                Password=password,
                Role=role,
            };

            try
            {
                context.UserInfos.AddRange(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            return user;
        }
    }
}
