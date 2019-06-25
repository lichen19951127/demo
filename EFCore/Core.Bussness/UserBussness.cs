using Core.Entity;
using ICore.Bussness;
using ICore.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Bussness
{
    public class UserBussness : IUserBussness
    {
        private readonly IUsersDataAccess _iuser;
        public UserBussness(IUsersDataAccess iuser)
        {
            _iuser = iuser;
        }
        public bool Delete(List<User> list)
        {
            return _iuser.Delete(list);
        }

        public List<User> GetList()
        {
            return _iuser.GetList();
        }

        public bool Insert(List<User> list)
        {
            return _iuser.Insert(list);
        }

        public bool Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
