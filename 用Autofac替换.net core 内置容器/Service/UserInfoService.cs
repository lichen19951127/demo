using IService;
using System;

namespace Service
{
    public class UserInfoService : IUserInfoService
    {
        public string GetUserInfo()
        {
            return "hello world,lc";
        }
    }
}
