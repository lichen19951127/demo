using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IService2;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public static IUserInfoService iuser;
        public static ITestService itest;
        public HomeController(IUserInfoService _iuser, ITestService _itest)
        {
            iuser = _iuser;
            itest = _itest;
        }
        public IActionResult Index()
        {
            var aaa = iuser.GetUserInfo();
            var bbb = itest.GetTest();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
