using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC伪静态
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute( // 不带参数的伪静态路由
                       name: "Index.html",
              url: "{controller}/{action}.html",
              defaults: new { controller = "Home", action = "Index" },
              namespaces: new[] { "MVC伪静态.Controllers" }
            );


            routes.MapRoute(
             "IDHtml", // 只有一个参数id的伪静态路由    
                     "{controller}/{action}/{id}.html",// 带有参数的 URL    
                     new { controller = "Home", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "MVC伪静态.Controllers" }
           );


            routes.MapRoute(//两个参数（id和pid）不带动作，伪静态
                      "TwoparameterNoAction",
              "{controller}/{action}/{id}/{pid}.html",
              new { controller = @"[a-zA-Z]", action = "Index", id = @"[\d]{0,6}", pid = UrlParameter.Optional },
              namespaces: new[] { "MVC伪静态.Controllers" }
            );


            routes.MapRoute( // 默认路由配置
                      name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "MVC伪静态.Controllers" }
            );
        }
    }
}
