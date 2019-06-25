using System;
using System.Reflection;
using System.Threading.Tasks;
using ECommon.Autofac;
using ECommon.Components;
using ECommon.Configurations;
using ECommon.Extensions;
using ECommon.IO;
using ECommon.JsonNet;
using ECommon.Log4Net;
using ECommon.Logging;
using ENode.Commanding;
using ENode.Configurations;

namespace BestQA.UnitTest
{
    public abstract class TestBase :IDisposable
    {
        protected static ICommandService _commandService;
        static ENodeConfiguration _configuration;

        static TestBase()
        {
            InitializeENode();
            _commandService = ObjectContainer.Resolve<ICommandService>();
        }

        protected CommandResult ExecuteCommand(ICommand command)
        {
            return _commandService.ExecuteAsync(command, CommandReturnType.EventHandled).WaitResult(3000).Data;
        }

        private static void InitializeENode()
        {
            var assemblies = new[]
            {
                Assembly.Load("BestQA.Domain"),
                Assembly.Load("BestQA.Commands"),
                Assembly.Load("BestQA.EventHandler"),
            };


            _configuration = Configuration
              .Create()
              .UseAutofac()
              .RegisterCommonComponents()
              .UseLog4Net()
              .UseJsonNet()
              .RegisterUnhandledExceptionHandler()
              .CreateENode()
              .RegisterENodeComponents()
              .RegisterBusinessComponents(assemblies)
              .RegisterAllTypeCodes()
              .UseEQueue()
              .InitializeBusinessAssemblies(assemblies)
              .StartEQueue();
        }

        public void Dispose()
        {
            _configuration.ShutdownEQueue();
        }
    }
}
