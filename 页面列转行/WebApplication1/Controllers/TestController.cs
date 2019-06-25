using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Content;

namespace WebApplication1.Controllers
{
    using Newtonsoft.Json;
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public string GetData()
        {
            var sql = "select * from Users";
           var list= DBHelper.ExecuteObjects<Users>(sql);
            return JsonConvert.SerializeObject(list);
        }


        public ActionResult Down()
        {
            Response.Redirect("/Test/Test");
            return Content("<script>location.href='/Content/新建 XLS 工作表.xls';</script>");
        }

        public ActionResult Table()
        {
            return View();
        }

    }
}