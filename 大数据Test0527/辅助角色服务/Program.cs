using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace 辅助角色服务
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //为了作为 Windows 服务运行，我们需要我们的 worker 监听来自 ServiceBase 的启动停止信号，该类型将 Windows 服务系统暴露给 .NET 应用程序。要做到这一点，我们希望：添加 Microsoft.Extensions.Hosting.WindowsServices NuGet 包
            // 这个方法做了两件事。首先，它检查应用程序是否真正的作为 Windows 服务运行，如果不是，那么它什么都不做，这使得这个方法很安全，当本地运行或作为 Windows 服务运行时。您不需要向其添加保护语句，只需在未作为 Windows 服务安装时正常运行应用程序即可。

            //其次，它将配置 host 使用 ServiceBaseLifetime。 ServiceBaseLifetime 与 ServiceBase 一起使用，以帮助控制作为 Windows 服务运行时应用程序的生命周期。这会覆盖处理 CTRL + C 等信号的默认的 ConsoleLifetime 。
                .UseWindowsService()
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
