using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using ICore.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess
{
    public class UsersDataAccess : IUsersDataAccess
    {
        private readonly TestDbContext _db;
        public UsersDataAccess(TestDbContext db)
        {
            _db = db;
        }
        public bool Delete(List<User> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                _db.Entry<User>(list[i]).State = EntityState.Deleted;
            }
            return _db.SaveChanges() > 0;
        }

        public List<User> GetList()
        {
            return _db.User.ToList();
        }

        public bool Insert(List<User> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                _db.User.Add(list[i]);
            }
            return _db.SaveChanges() > 0;
        }

        public bool Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
