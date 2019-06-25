using System;
using System.Collections.Generic;

namespace IDAL
{
    using Entity;
    public interface IUsers_DAL
    {
        string GetValue();
        List<Users> Query();
    }
}
