using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt
{
    /// <summary>
    /// 中间件
    /// </summary>
    public class UseJwtMiddleware
    {
        private readonly RequestDelegate _next;
        private JwtConfig _jwtConfig = new JwtConfig();
        private IJwt _jwt;
        public UseJwtMiddleware(RequestDelegate next, IConfiguration configration, IJwt jwt)
        {
            _next = next;
            this._jwt = jwt;
            configration.GetSection("Jwt").Bind(_jwtConfig);
        }
        public Task InvokeAsync(HttpContext context)
        {
            if (_jwtConfig.IgnoreUrls.Contains(context.Request.Path))
            {
                return this._next(context);
            }
            else
            {
                if (context.Request.Headers.TryGetValue(this._jwtConfig.HeadField, out Microsoft.Extensions.Primitives.StringValues authValue))
                {
                    var authstr = authValue.ToString();
                    if (this._jwtConfig.Prefix.Length > 0)
                    {
                        authstr = authValue.ToString().Substring(this._jwtConfig.Prefix.Length + 1, authValue.ToString().Length - (this._jwtConfig.Prefix.Length + 1));
                    }
                    if (this._jwt.ValidateToken(authstr, out Dictionary<string, string> Clims) && !Jwt.InvalidateTokens.Contains(authstr))
                    {
                        List<string> climsKeys = new List<string>() { "nbf", "exp", "iat", "iss", "aud" };
                        IDictionary<string, string> RenewalDic = new Dictionary<string, string>();
                        foreach (var item in Clims)
                        {
                            if (climsKeys.FirstOrDefault(o => o == item.Key) == null)
                            {
                                context.Items.Add(item.Key, item.Value);
                                RenewalDic.Add(item.Key, item.Value);
                            }
                        }
                        //验证通过的情况下判断续期时间
                        if (Clims.Keys.FirstOrDefault(o => o == "exp") != null)
                        {
                            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                            var timespan = long.Parse(Clims["exp"]);
                            var expDate = start.AddSeconds(timespan).ToLocalTime();
                            var o = expDate - DateTime.Now;
                            if (o.TotalMinutes < _jwtConfig.RenewalTime)
                            {
                                //执行续期当前Token立马失效
                                var newToken = this._jwt.GetToken(RenewalDic, authstr);
                                //var newToken=this._jwt.GetToken(RenewalDic);//生成新Token当前Token仍可用，过期时间以Lifetime设置为准
                                context.Response.Headers.Add(_jwtConfig.ReTokenHeadField, newToken);
                            }
                        }
                        return this._next(context);
                    }
                    else
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        return context.Response.WriteAsync("{\"status\":401,\"statusMsg\":\"auth vaild fail\"}");
                    }
                }
                else
                {
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";
                    return context.Response.WriteAsync("{\"status\":401,\"statusMsg\":\"auth vaild fail\"}");
                }
            }
        }
    }

    /// <summary>
    /// 中间件暴露出去
    /// </summary>
    public static class UseUseJwtMiddlewareExtensions
    {
        /// <summary>
        /// 权限检查
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseJwt(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UseJwtMiddleware>();
        }
    }
}
