using JwtApi.Interfaces;
using JwtApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    [ApiController]
    public class UserInfoController : Controller
    {
        private readonly IUserInfo userInfoService;

        public UserInfoController(IUserInfo userInfoService)
        {
            this.userInfoService = userInfoService;
        }
        [Authorize]
        [HttpGet("getUserInfo/{id}")]
        public ActionResult<UserInfo> getUserInfo(int id)
        {
            var userInfo = userInfoService.getUserInfo(id);
            return Ok(userInfo);
        }

        [Authorize]
        [HttpGet("getUsersInfo")]
        public ActionResult<UserInfo> getUsersInfo()
        {
            var usersInfo = userInfoService.getUsersInfo();
            return Ok(usersInfo);
        }
    }
}
