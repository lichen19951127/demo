﻿using System.Web;
using System.Web.Mvc;

namespace NewLife.XCode.WebNet
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
