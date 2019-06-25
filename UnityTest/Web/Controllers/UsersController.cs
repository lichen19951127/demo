using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    using IBLL;
    using Entity;
    public class UsersController : Controller
    {
        private IUsers_BLL iUsers_BLL;
        public UsersController(IUsers_BLL _iUsers_BLL)
        {
            iUsers_BLL = _iUsers_BLL;
        }
        // GET: Users
        public ActionResult Index()
        {
           var result= iUsers_BLL.GetValues();
            return View();
        }
    }
}