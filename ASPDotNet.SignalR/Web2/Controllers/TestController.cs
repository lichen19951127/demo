using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web2.Controllers
{
    public class TestController : Controller
    {

        /// <summary>
        /// 采用集线器类（Hub）+自动生成代理模式
        /// </summary>
        /// <returns></returns>
        public ActionResult Index1(string id,string sid)
        {
            ViewBag.ClientName = "聊客-" + id;
            ViewBag.UId = sid;
            //var onLineUserList = ChatHub.OnLineUsers.Select(u => new SelectListItem() { Text = u.Value, Value = u.Key }).ToList();
            //onLineUserList.Insert(0, new SelectListItem() { Text = "-所有人-", Value = "" });
            //ViewBag.OnLineUsers = onLineUserList;
            return View();
        }
        /// <summary>
        /// 采用持久化连接类（PersistentConnection）
        /// </summary>
        /// <returns></returns>
        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult Index4()
       {
        return View();
        }
    }
}