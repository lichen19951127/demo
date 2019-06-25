using System;

namespace DotNetCore.Service
{
    using System.Collections.Generic;
    using DotNetCore.Entity;
    using DotNetCore.IService;
    using DotNetCore.DataAccess;
    public class Users_Service :SqlSugarBaseClient, IUsers_Service
    {
        public bool Add(Users t)
        {
            return DB.Insertable<Users>(t).ExecuteCommand()>0;
        }

        public bool Delete(string Id)
        {
            return DB.Deleteable<Users>().In(Id).ExecuteCommand() > 0;
        }

        public List<Users> Query()
        {
            throw new NotImplementedException();
        }

        public Users QueryById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Users t)
        {
            throw new NotImplementedException();
        }
    }
}
