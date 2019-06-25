using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Web
{
    using Entity;
    using Unity.Mvc5;
    using Unity;
    using IDAL;
    using DAL;
    using BLL;
    using IBLL;
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            //业务逻辑层
            container.RegisterType<IUsers_BLL, UsersBLL>();
            //数据访问层
            container.RegisterType<IUsers_DAL, UsersDAL>();
        }
    }
}