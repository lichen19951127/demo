using Autofac;
using IService2;
using Service2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserInfoService>().As<IUserInfoService>();
            builder.RegisterType<TestService>().As<ITestService>();
        }
    }
}
