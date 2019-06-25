using IService2;
using System;

namespace Service2
{
    public class UserInfoService : IUserInfoService
    {
        public string GetUserInfo()
        {
            return "hello world,lc";
        }
    }
}
