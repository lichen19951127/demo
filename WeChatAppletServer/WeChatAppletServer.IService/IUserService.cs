using System;
using System.Collections.Generic;
using System.Text;
using WeChatAppletServer.Entity;

namespace WeChatAppletServer.IService
{
    public interface IUserService:IBaseService<Users>
    {
        List<Users> GetList();
    }
}
