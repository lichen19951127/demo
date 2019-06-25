using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    using IService;
   public class UserInfosService : IUserInfosService
    {
        public string GetUserInfos()
        {
            return "This is UserInfos";
        }

        public string GetValue()
        {
            return "Hello World,UserInfos!";
        }
    }
}
