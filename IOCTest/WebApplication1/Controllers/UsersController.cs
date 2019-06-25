using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    using Entity;
    using BLL;
    using IBLL;
    public class UsersController : Controller
    {
        private IUsers_BLL ibll;
        public UsersController(IUsers_BLL _ibll)
        {
            ibll = _ibll;
        }

        public ActionResult Index()
        {
            ViewBag.Users = ibll.QueryById(2);
            return View();
        }
        public ActionResult Add()
        {
            Users u = new Users();
            u.Name = "马启琛";
            var i = ibll.Add(u);
            return View();
        }
    }
}