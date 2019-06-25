using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(HomeController));
        public IActionResult Index()
        {
            log.Info("test index view");
            log.Error("Controller Error");
            return View();
        }
    }
}