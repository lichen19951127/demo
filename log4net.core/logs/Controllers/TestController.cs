using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace logs.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                var b = 0;
                int a = 10 / b;
            }
            catch (Exception ex)
            {

              ErrorLog.WriteLog(ex);
            }
            return View();
        }
    }
}