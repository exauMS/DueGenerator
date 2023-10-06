using JwtApi.Models;

namespace JwtApi
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if(!dataContext.UserInfos.Any())
            {
                var user = new UserInfo
                {
                    Email= "bob@gmail.com",
                    UserName="Bob",
                    Role="admin",
                    Password="user-admin123"
                };

                dataContext.UserInfos.AddRange(user);
                dataContext.SaveChanges();
            }
        }

    }
}
