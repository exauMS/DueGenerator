using JwtApi.Models;

namespace JwtApi.Interfaces
{
    public interface IUserInfo
    {
        public UserInfo getUserInfo(int id);
        public List<UserInfo> getUsersInfo();
    }
}
