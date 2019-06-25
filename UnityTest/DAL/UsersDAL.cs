using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    using Dapper;
    using Entity;
    using IDAL;
    using System.Data;
    using System.Data.SqlClient;
    public class UsersDAL : IUsers_DAL
    {
        private IDbConnection conn = null;
        public UsersDAL()
        {
            if (conn == null)
                conn = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=lianxi1031;User ID=sa;Password=sa;");
        }
        public string GetValues()
        {
            var i = 100.GetDouble();
            return "正在使用Unity".CutString();
        }


        public int Add(Users u)
        {
            var sql = "insert into Users values(@Name)";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@Name",u.Name);
            var result = conn.Execute(sql, dp);
            return result;
        }

        public int Delete(string Ids)
        {
           
            return 0;
        }

       

        public List<Users> Query()
        {
            var sql = "select * from Users";
            var result = conn.Query<Users>(sql).ToList();
            return result;
        }

        public Users QueryById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(Users u)
        {
            throw new NotImplementedException();
        }
    }
}
