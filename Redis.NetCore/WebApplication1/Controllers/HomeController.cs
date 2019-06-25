using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            #region --测试redis--
            // var a=RedisHelperNetCore.Default.StringSet("redis", "redis" + DateTime.Now, TimeSpan.FromSeconds(1000000));
            //var b = RedisHelperNetCore.Default.StringGet("redis");
            //var c= RedisHelper.Default.KeyDelete("redis");
            #endregion

            #region 测试cache
            //写入
            CacheHelperNetCore.CacheInsertAddMinutes("cache","123",10);
            //读取
           string value= CacheHelperNetCore.CacheValue("cache").ToString();
            //清除
            CacheHelperNetCore.CacheNull("cache");
            string value1 = CacheHelperNetCore.CacheValue("cache").ToString();
            #endregion
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
