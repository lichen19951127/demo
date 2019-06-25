using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoNet.WebApi.Controllers
{
    using DoNet.Entity;
    using DoNet.Service;
    [RoutePrefix("DoNet")]
    public class UsersApiController : ApiController
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public Users Login(string name, string pwd)
        {
            var result = UserService.Login(name,pwd);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryUsers")]
        public List<Users> Query()
        {
            var result = UserService.Query();
            return result;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUser")]
        public int Add(Users model)
        {
            var result = UserService.Add(model);
            return result;
        }
    }
}
