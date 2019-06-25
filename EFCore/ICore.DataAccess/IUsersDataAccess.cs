using System;
using System.Collections.Generic;
using Core.Entity;
using System.Text;

namespace ICore.DataAccess
{
    public interface IUsersDataAccess
    {
        List<User> GetList();
        bool Insert(List<User> list);
        bool Delete(List<User> list);
        bool Update(User model);
    }
}
