﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_VUE
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
