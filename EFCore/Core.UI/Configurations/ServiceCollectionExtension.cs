using Core.Bussness;
using Core.DataAccess;
using ICore.Bussness;
using ICore.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.UI.Configurations
{
    public static class ServiceCollectionExtension
    {
        internal static void AddIocConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUsersDataAccess, UsersDataAccess>();
            services.AddScoped<IUserBussness, UserBussness>();
        }
    }
}
