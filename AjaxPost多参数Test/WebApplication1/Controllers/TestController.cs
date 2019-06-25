using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model,string title,int type=0)
        {

            return View();
        }
    }
    public class LoginModel
    {
        public string Name { get; set; }
        public string Pwd { get; set; }
    }
}