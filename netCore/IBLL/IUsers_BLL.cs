using Entity;
using System;
using System.Collections.Generic;

namespace IBLL
{

    public interface IUsers_BLL
    {
        string GetValue();
        List<Users> Query();
    }
}
