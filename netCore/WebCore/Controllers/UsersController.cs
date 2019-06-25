using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCore.Controllers
{
    using IBLL;
    using Entity;
    public class UsersController : Controller
    {
        public IUsers_BLL iUsers_BLL;
        public UsersController(IUsers_BLL _iUsers_BLL)
        {
            iUsers_BLL = _iUsers_BLL;
        }
        public IActionResult Index()
        {
            var hello = iUsers_BLL.GetValue();
            ViewBag.test = iUsers_BLL.Query();
            return View();
        }
    }
}