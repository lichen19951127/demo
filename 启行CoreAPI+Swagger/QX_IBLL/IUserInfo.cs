using System;
using System.Collections.Generic;
using QX_Models;
namespace QX_IService
{
    public interface IUserInfo
    {
        bool Add(UserInfo model);

        bool Update(UserInfo model);

        bool Delete(string ids);

        List<UserInfo> GetList();

        UserInfo GetModel();

    }
}
