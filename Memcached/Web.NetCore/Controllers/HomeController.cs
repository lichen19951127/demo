using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.NetCore.Models;

namespace Web.NetCore.Controllers
{
    using Enyim.Caching;
    public class HomeController : Controller
    {
        private IMemcachedClient _memcachedClient;//调用memcachedcore3
        public HomeController(IMemcachedClient memcachedClient)
        {
            _memcachedClient = memcachedClient;//赋值memcachedcore4
        }
        public IActionResult Index()
        {
            #region --测试memcachedcore--

            MemcachedHelper.Set("memcached", "memcached-core", "memcachedcore" + DateTime.Now, 60);
            string mh = MemcachedHelper.Get("memcached-core").ToString();
            ViewData["mhelper"] = mh;

            //这种方式暂未找到合适赋值，待研究，赋值赋不上。
            //删/增/取memcachedcore5
            //var cacheKey = "memcachedcore";
            ////_memcachedClient.Add(cacheKey, "memcachedcore" + DateTime.Now, 60);//此方法赋不上值
            ////var result = _memcachedClient.Get(cacheKey);
            //_memcachedClient.Remove(cacheKey);
            //ViewData["memcachedcore"] = result.ToString();
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
