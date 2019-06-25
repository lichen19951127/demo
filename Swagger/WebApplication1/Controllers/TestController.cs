using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("YiXin")]
    public class TestController : ApiController
    {
        /// <summary>
        /// 获取数据1
        /// </summary>
        /// <returns>返回123</returns>
        [Route("GetData")]
        [HttpPost]
        public string Query()
        {
            return "123";
        }

        //GET:YiXin/GetData2/5
        [Route("GetData2")]
        [HttpGet]
        public string Query2(int id)
        {
            return id.ToString();
        }
    }
}
