using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index2()
        {
            return Content("<script>alert('跳转成功');location.href='/Users/Item';</script>", "text/html;charset=utf-8");
        }

        public IActionResult Item()
        {
            return View();
        }
    }
}