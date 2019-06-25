using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index2()
        {
            return Content("<script>alert('跳转成功');location.href='/Test/Item';</script>");
            //"text/html;charset=utf-8"可不设置
        }
        public ActionResult Item()
        {
            return View();
        }
    }
}