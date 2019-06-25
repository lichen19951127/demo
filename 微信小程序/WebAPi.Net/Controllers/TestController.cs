using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPi.Net.Controllers
{
    using Newtonsoft.Json;
    [RoutePrefix("Wx")]
    public class TestController : ApiController
    {
        [Route("GetData")]
        [HttpGet]
        public string GetData(int Id)
        {
            Users user = new Users()
            {
                Id = 1,
                Name = "张三"
            };
            return JsonConvert.SerializeObject(user);
        }
        [Route("Login")]
        [HttpPost]
        public int Login(Users users)
        {
            if (users.Id == 1 && users.Name == "张三")
            {
                return 200;
            }
            else
            {
                return 500;
            }
        }
    }
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
