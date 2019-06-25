using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vue.Entity;

namespace Vue.Api.Controllers
{
    [EnableCors("AllowSameDomain")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        [HttpGet]
        public bool Login(string name,string pwd)
        {
            if (name == "admin" && pwd == "admin")
                return true;
            else
            return false;
        }

        [HttpGet]
        public List<User> Query()
        {
            List<User> list = new List<User>();
            User u1 = new User() {Id=1,Name="张三",Pwd="123" };
            User u2 = new User() { Id = 1, Name = "张三", Pwd = "123" };
            User u3 = new User() { Id = 1, Name = "张三", Pwd = "123" };
            User u4 = new User() { Id = 1, Name = "张三", Pwd = "123" };
            User u5 = new User() { Id = 1, Name = "张三", Pwd = "123" };
            list.Add(u1);
            list.Add(u2);
            list.Add(u3);
            list.Add(u4);
            list.Add(u5);
            return list;
        }
    }
}