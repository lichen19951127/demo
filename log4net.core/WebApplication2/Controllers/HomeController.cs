using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(HttpGlobalExceptionFilter));
        public IActionResult Index()
        {
            throw new Exception("自定义异常！！！");  //有异常则会记录到logfile文件夹中
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            log.Info("打开about页面了！！！"); //普通的记录日志
            return View();
        }

    }
}