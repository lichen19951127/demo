﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Net
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MemcacheHelper.RegisterMemcache();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
