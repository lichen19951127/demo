using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Web
{
    /// <summary>
    /// 通过输入的程序集来注册满足约定的所有类
    /// </summary>
    public class BasicConventionalRegistrar
    {
        private readonly WindsorContainer _container = new WindsorContainer();

        /// <summary>
        /// 注册程序集中满足约定的类
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public WindsorContainer RegisterAssembly(List<Assembly> assemblies)
        {
            //foreach (var assembly in assemblies)
            //{
            //    //Transient
            //    _container.Register(
            //        Classes.FromAssembly(assembly)
            //               .IncludeNonPublicTypes()
            //               .BasedOn<ITransientDependency>()
            //               .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
            //               .WithService.Self()
            //               .WithService.DefaultInterfaces()
            //               .LifestyleTransient()
            //    );

            //    //Singleton
            //    _container.Register(
            //        Classes.FromAssembly(assembly)
            //               .IncludeNonPublicTypes()
            //               .BasedOn<ISingletonDependency>()
            //               .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
            //               .WithService.Self()
            //               .WithService.DefaultInterfaces()
            //               .LifestyleSingleton()
            //    );
            //}
            return _container;
        }
    }
}
