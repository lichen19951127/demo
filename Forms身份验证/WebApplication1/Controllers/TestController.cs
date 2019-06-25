using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.name == "1" && user.pwd == "1")
            {
                FormsAuthentication.SetAuthCookie(user.name,false);
                return Redirect("/Test/Index");
            }
            return Redirect("/Test/Login");
        }
    }
    public class User
    {
        public string name { get; set; }
        public string pwd { get; set; }
    }
}