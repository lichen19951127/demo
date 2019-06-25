using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Ashx
{
    using Newtonsoft.Json;
    /// <summary>
    /// MyHandler 的摘要说明
    /// </summary>
    public class MyHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var Id = context.Request["Id"];
            var Name = context.Request["Name"];
            var result = "Hello World," + Name+Id.ToString();
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}