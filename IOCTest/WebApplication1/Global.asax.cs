using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using System.Reflection;
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //声明一个容器注册
            ContainerBuilder builder = new ContainerBuilder();
            //注册mvc所有的控制器类
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //对数据访问层做注入
            builder.RegisterType<DAL.UsersDAL>().As<IDAL.IUsers_DAL>();

            //对业务逻辑层注入
            builder.RegisterType<BLL.UsersBLL>().As<IBLL.IUsers_BLL>();

            IContainer container = builder.Build();

            //解析依赖关系
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
