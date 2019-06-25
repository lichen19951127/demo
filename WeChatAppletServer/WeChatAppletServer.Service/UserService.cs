using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WeChatAppletServer.Entity;
using WeChatAppletServer.IService;

namespace WeChatAppletServer.Service
{
    public class UserService : BaseRepository, IUserService
    {
        public bool Add(Users t)
        {
            var sql = string.Format("insert into Users(Name,Sex,Age) values('{0}','{1}','{2}')",t.Name,t.Sex,t.Age);
            var result = 0;
            using (var conn = GetSqlConnection())
            {
                result = conn.Execute(sql);
            }
            return result>0;
        }

        public bool Delete(int Id)
        {
            var sql = string.Format("delete from Users where Id='{0}'", Id);
            var result = 0;
            using (var conn = GetSqlConnection())
            {
                result = conn.Execute(sql);
            }
            return result>0;
        }

        public List<Users> GetList()
        {
            var sql = string.Format("select * from Users ");
            var result = new List<Users>();
            using (var conn = GetSqlConnection())
            {
                result = conn.Query<Users>(sql).ToList();
            }
            return result;
        }

        public Users GetSingle(int Id)
        {
            var sql = string.Format("select * from Users where Id='{0}'", Id);
            var result = new Users();
            using (var conn = GetSqlConnection())
            {
                result = conn.QueryFirst<Users>(sql);
            }
            return result;
        }

        public bool Update(Users t)
        {
            var sql = string.Format("update Users set Name='{0}',Sex='{1}',Age='{2}' where Id='{3}'", t.Name, t.Sex, t.Age, t.Id);
            var result = 0;
            using (var conn = GetSqlConnection())
            {
                result = conn.Execute(sql);
            }
            return result>0;
        }
    }
}
