using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Entity;
using ICore.Bussness;
using Core.UI.Models;

namespace Core.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserBussness _iuserbus;
        public HomeController(IUserBussness iuserbus)
        {
            _iuserbus = iuserbus;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetList()
        {
            List<User> list = _iuserbus.GetList();
            return Json(list);
        }
        public bool Insert(User entity)
        {
            List<User> list = new List<User>();
            list.Add(entity);
            return _iuserbus.Insert(list);
        }
        public bool Delete(List<User> list)
        {
            return _iuserbus.Delete(list);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
