using System;

namespace DAL
{
    using System.Collections.Generic;
    using Entity;
    using IDAL;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Options;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class UsersDAL : IUsers_DAL
    {
       private readonly IOptions<ConnectionStrings> connectionSetting;

        private readonly EFDbContext dbContext;

        //private readonly 
        public UsersDAL(IOptions<ConnectionStrings> _connectionSetting, EFDbContext _dbContext)
        {
            connectionSetting = _connectionSetting;
            dbContext = _dbContext;
        }
        public string GetValue()
        {
            return "Hello World";
        }
        
        public List<Users> Query()
        {

            //根据Configrution对象的属性形式获取
            string connStr = connectionSetting.Value.conn;

            //string connStr2 = connectionSetting["ConnectionSettings:ConnectionStrings"];
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    SqlCommand cmd = new SqlCommand("select * from Users", conn);
            //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    sda.Fill(dt);
            //    return dt.ToList<Users>();
            //}
            List<Users> user = dbContext.Users.ToList();
            return user;
        }
    }
}
