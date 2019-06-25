using Autofac;
using IService;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<UserInfoService>().As<IUserInfoService>();
            //builder.RegisterType<TestService>().As<ITestService>();
            builder.RegisterType<UserInfoService>().As<IUserInfoService>().SingleInstance();
            //builder.RegisterType<TestService>().InstancePerLifetimeScope();
            //builder.RegisterType<ETagCache>().InstancePerLifetimeScope();
            // builder.RegisterType<TestService>().As<ITestService>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<TestService>().As<ITestService>().InstancePerLifetimeScope();
        }
    }
}
