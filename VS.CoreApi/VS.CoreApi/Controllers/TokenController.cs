using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VS.Common;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Model;

namespace VS.CoreApi.Controllers
{
    /// <summary>
    /// 获取Token
    /// </summary>
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetToken()
        {
            //用户为空 返回403
            UserInfor user = new UserInfor();
            if (user == null) Unauthorized();

            //从配置文件获取token信息
            string securityKey = AppsettingsHelper.GetConfigString("Authorize", "SecurityKey");
            string audience = AppsettingsHelper.GetConfigString("Authorize", "Audience");
            string issuer = AppsettingsHelper.GetConfigString("Authorize", "Issuer");
            var byteArrayKey = Encoding.ASCII.GetBytes(securityKey);

            var tokenHandler = new JwtSecurityTokenHandler();
            var authTime = DateTime.UtcNow;
            var expriesAt = authTime.AddHours(1);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim("aud",audience), //听众
                    new Claim("iss",issuer),//发行人
                    new Claim(ClaimTypes.Name,"liuzhihang"), //用户名
                }),
                Expires = expriesAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteArrayKey), SecurityAlgorithms.HmacSha256), //签发凭证
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);

            //返回结果
            return Ok(new
            {
                access_token = tokenStr,
                token_type="Bearer",
                profile = new
                {
                    auth_time = authTime,
                    expries_at = expriesAt 
                }
            });
        }
    }
}