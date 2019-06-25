using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IService;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        protected IUsersService _iUsersService;
        protected IUserInfosService _iUserInfosService;
        public TestController(IUsersService iUsersService, IUserInfosService iUserInfosService)
        {
            _iUsersService = iUsersService;
            _iUserInfosService = iUserInfosService;
        }
        public IActionResult Index()
        {
           var a= _iUsersService.GetValue();
           var b= _iUsersService.GetUsers();
           var c = _iUserInfosService.GetValue();
           var d = _iUserInfosService.GetUserInfos();
            return View();
        }
    }
}