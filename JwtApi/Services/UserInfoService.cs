using JwtApi.Interfaces;
using JwtApi.Models;

namespace JwtApi.Services
{
    public class UserInfoService : IUserInfo
    {
        private readonly DataContext dataContext;

        public UserInfoService(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }
        public UserInfo getUserInfo(int id)
        {
            return dataContext.UserInfos.Find(id);
        }

        public List<UserInfo> getUsersInfo()
        {
            return dataContext.UserInfos.ToList();
        }
    }
}
