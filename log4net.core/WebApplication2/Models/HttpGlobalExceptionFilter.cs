﻿using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    /// <summary>
    /// 全局异常类
    /// </summary>
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(HttpGlobalExceptionFilter));
        public void OnException(ExceptionContext context)
        {
            log.Error(context.Exception);
        }
    }
}