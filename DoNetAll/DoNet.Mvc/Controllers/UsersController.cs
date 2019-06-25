using DoNet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoNet.Mvc.Controllers
{
    using DoNet.Entity;
    using Newtonsoft.Json;
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var json = Client.GetApi("post", "QueryUsers");
            var user = JsonConvert.DeserializeObject<List<Users>>(json);
            ViewBag.UserList = user;
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name,string pwd)
        {
           var json= Client.GetApi("post","Login?name="+name+"&pwd="+pwd);
            var user = JsonConvert.DeserializeObject<Users>(json);
            var result = "";
            if (user!=null)
                result = "alert('success');location.href='/Users/Index'";
            else
                result = "alert('error')";
            return Content("<script>" + result+"</script>");
        }
    }
}