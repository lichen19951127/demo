using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IService
{
   public interface IUsersService:IBaseService<Users>
    {
        List<Users> Query();
    }
}
