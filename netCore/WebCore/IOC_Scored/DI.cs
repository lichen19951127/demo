using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.IOC_Scored
{
    using BLL;
    using DAL;
    using IBLL;
    using IDAL;
    public static class DI
    {
        public static void AddScored(this IServiceCollection service)
        {
            service.AddScoped<IUsers_BLL, UsersBLL>();
            service.AddScoped<IUsers_DAL, UsersDAL>();
        }
    }
}
