using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IService
{
    public interface IUsersService: IServiceBase<Users>
    {
        string GetUsers();
    }
}
