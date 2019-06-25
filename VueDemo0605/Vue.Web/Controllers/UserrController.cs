using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vue.Web.Controllers
{
    public class UserrController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}