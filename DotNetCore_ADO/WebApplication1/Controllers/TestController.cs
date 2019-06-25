using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var sql1 = "insert into [User] values(@Name)";
            DbParameters dp = new DbParameters();
            dp.Add("@Name","张三");
            var a = new DbHelper().ExecuteSql(sql1,dp);
            DbParameters dp1 = new DbParameters();
            dp1.Add("@Name", "李四");
            var a1 = new DbHelper().ExecuteSql(sql1, dp1);

            var dt = new DbHelper().CreateSqlDataTable("select * from [User]");

            var sql2 = "delete from [User] where Id=@id";
            DbParameters dp2 = new DbParameters();
            dp2.Add("@id",1);
            var b = new DbHelper().ExecuteSql(sql2, dp2);

            var dt2 = new DbHelper().CreateSqlDataTable("select * from [User]");

            var name = new DbHelper().CreateSqlScalar("select Name from [User] where Id=2");

            return View();
        }
    }
}