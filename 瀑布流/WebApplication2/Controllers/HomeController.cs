using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult PuBu()
        {
            return View();
        }

        public JsonResult GetData()
        {
            Random ro = new Random();
            List<int> vListInt = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                vListInt.Add(ro.Next(400, 500));
            }
            return Json(vListInt, JsonRequestBehavior.AllowGet);
        }
    }
}