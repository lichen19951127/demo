using DotNetCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.IService
{
    public interface IUsers_Service:IBase<Users>
    {
        List<Users> Query();
    }
}
