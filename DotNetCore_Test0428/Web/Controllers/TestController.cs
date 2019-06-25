using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web.Controllers
{
    using Newtonsoft.Json;
    public class WebApiConsumer
    {
        protected static HttpClient singletonClient;
        static WebApiConsumer()
        {
            TimeSpan timeSpan = new TimeSpan(0, 10, 0);
            HttpClientHandler hander = new HttpClientHandler();
            hander.UseProxy = false;
            singletonClient = new HttpClient(hander) { Timeout = timeSpan };
        }



    }
    public class TestController : Controller
    {
        //protected TestService testService { get; }
        //public TestController(TestService _testService)
        //{
        //    testService = _testService;
        //}
       
        public IActionResult Index()
        {
            //var a=testService.GetValue();


            return View();
        }
       

    }
   
}