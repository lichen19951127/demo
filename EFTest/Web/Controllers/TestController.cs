using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Service;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        public IService<Users> iService;
        public TestController(IService<Users> _iService)
        {
            iService = _iService;
        }
        public IActionResult Index()
        {
            var list=iService.Query();

            var list1 = list.Where(m => m.Name.StartsWith("张三")).ToList();
            var list2 = list.Where(m => m.Name.StartsWith("张三1")).ToList();
            var list3 = list.Where(m => m.Name.StartsWith("李四")).ToList();
            var list4 = list.Where(m => m.Name.EndsWith("张三")).ToList();
            Users u = new Users();
            u.Id = Guid.NewGuid().ToString();
            u.Name = "张三";
            u.CreateDate = DateTime.Now;
            var ss=iService.Add(u);

            u.Name = "李四";
            var sss = iService.Update(u);

            return View();
        }
    }
}