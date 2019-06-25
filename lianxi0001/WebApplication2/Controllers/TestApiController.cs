using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    [RoutePrefix("TestApi")]
    public class TestApiController : ApiController
    {
        [HttpPost]
        [Route("GetApi")]
        public string GetValue()
        {
            return "这是api";
        }
    }
}
