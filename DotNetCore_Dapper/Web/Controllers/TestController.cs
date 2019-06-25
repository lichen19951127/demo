using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using IService;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        protected IUsersService _iUsersService;
        public TestController(IUsersService iUsersService)
        {
            _iUsersService = iUsersService;
        }
        public IActionResult Index()
        {
            Users u = new Users();
            u.Id = 1;
            u.Name = "张三";
           var a= _iUsersService.Add(u);
            Users u1 = new Users();
            u1.Id = 2;
            u1.Name = "李四";
            var a1 = _iUsersService.Add(u1);
            Users u2 = new Users();
            u2.Id = 3;
            u2.Name = "王五";
            var a2 = _iUsersService.Add(u2);

            var q1 = _iUsersService.Query();

           var b= _iUsersService.Delete(1);
            var q2 = _iUsersService.Query();
            var uu = _iUsersService.QueryById(2);
            uu.Name = "李四123";
            var uu1 = _iUsersService.Update(uu);
            var q3= _iUsersService.Query();


            return View();
        }
    }
}