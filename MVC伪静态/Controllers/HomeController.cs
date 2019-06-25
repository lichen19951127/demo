using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC伪静态.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Vue()
        {
            return View();
        }
        public ActionResult Jquery()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}