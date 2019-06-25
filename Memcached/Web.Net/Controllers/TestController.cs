using Enyim.Caching;
using Enyim.Caching.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Net.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            User user = new User();
            user.Id = 1;
            user.Name = "张三";

            MemcacheHelper.GetInstance().Add("1", "123");
            var a = MemcacheHelper.GetInstance().Get("1");

            return View();
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}