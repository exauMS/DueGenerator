using JwtApi.Interfaces;
using JwtApi.Models;

namespace JwtApi.Services
{
    public class DeleteService : IDeleteService
    {
        private readonly DataContext context;

        public DeleteService(DataContext context)
        {
            this.context = context;
        }
        public string delete(int id)
        {
           var user = context.UserInfos.Where(u => u.Id == id).FirstOrDefault();

            try
            {
                context.Remove(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "User " + user.UserName + " has been deleted!";

        }
    }
}
