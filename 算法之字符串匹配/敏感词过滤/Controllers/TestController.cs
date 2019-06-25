using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 敏感词过滤.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/xmlconfig/badword.txt");
            FilterHelper filter = new FilterHelper(path); //存放敏感词的文档
            filter.SourctText = "中国共产党万岁";
            string resultStr = filter.Filter('*');
            return View();
        }
    }
}