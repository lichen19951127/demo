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