using IService;
using System;

namespace Service
{
    public class UsersService : IUsersService
    {
        public string GetUsers()
        {
            return "This is Users";
        }

        public string GetValue()
        {
            return "Hello World,Users!";
        }
    }
}
