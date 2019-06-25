using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Content;
using Web.Models;

namespace Web.Service
{
    public class UserService : IService<Users>
    {
        private readonly EFDBContext dbContext;
        public UserService(EFDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public int Add(Users t)
        {
            dbContext.Users.Add(t);
            var result = dbContext.SaveChanges();
            return result;
        }

        public List<Users> Query()
        {
            var result = dbContext.Users.ToList();
            return result;
        }

        public Users QueryById(string Id)
        {
            var result = dbContext.Users.Find(Id);
            return result;
        }

        public int Update(Users t)
        {
            dbContext.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var result = dbContext.SaveChanges();
            return result;
        }
    }
}
