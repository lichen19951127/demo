using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    using Newtonsoft.Json;
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.data = getDatalist();
            return View();
        }
        public List<Info> getDatalist()
        {
            List<Info> list = new List<Info>();
            for (int i = 0; i < 5; i++)
            {
                Info inf = new Info();
                inf.Num = i + 1;
                list.Add(inf);
            }
            return list;
        }
        public string getData()
        {
            List<Info> list = new List<Info>();
            for (int i = 0; i < 5; i++)
            {
                Info inf = new Info();
                inf.Num = i+1;
                list.Add(inf);
            }
            return JsonConvert.SerializeObject(list);
        }
    }
    public class Info
    {
        public int Num { get; set; }
    }
}