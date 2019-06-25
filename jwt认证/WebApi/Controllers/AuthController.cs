using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IJwt _jwt;
        public AuthController(IJwt jwt)
        {
            this._jwt = jwt;
        }
        /// <summary>
        /// getToken
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetToken(UserInfo userInfo)
        {
            if (true)
            {
                Dictionary<string, string> clims = new Dictionary<string, string>();
                clims.Add("userName", userInfo.userName);
                return new JsonResult(this._jwt.GetToken(clims));
            }
        }

        /// <summary>
        /// 强制Token失效
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InvalidateToken(string Token)
        {
            return new JsonResult(this._jwt.InvalidateToken(Token));
        }
    }
    public class UserInfo
    {
        public string userName { get; set; }
        public string passWord { get; set; }
    }
}