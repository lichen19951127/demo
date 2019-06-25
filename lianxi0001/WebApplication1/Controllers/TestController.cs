using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        MyServiceReference1.WebService1SoapClient myService = new MyServiceReference1.WebService1SoapClient();
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.testService = myService.HelloWorld();
            return View();
        }
    }
}