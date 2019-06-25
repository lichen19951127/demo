using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IService
{
    public interface IUserInfosService:IServiceBase<UserInfos>
    {
        string GetUserInfos();
    }
}
