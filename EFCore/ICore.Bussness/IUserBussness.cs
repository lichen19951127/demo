using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICore.Bussness
{
    public interface IUserBussness
    {
        List<User> GetList();
        bool Insert(List<User> list);
        bool Delete(List<User> list);
        bool Update(User model);
    }
}
