using System;
using Topshelf;

namespace TopshelfDemoService
{
    /// <summary>
    /// 配置服务类 配置Topshelf服务的各种运行参数
    /// </summary>
    internal class MyServiceConfigure
    {
        internal static void Configure()
        {
            var rc = HostFactory.Run(host =>                                    // 1
            {
                host.Service<HealthMonitorService>(service =>                   // 2
                {
                    service.ConstructUsing(() => new HealthMonitorService());   // 3
                    service.WhenStarted(s => s.Start());                        // 4
                    service.WhenStopped(s => s.Stop());                         // 5
                });

                host.RunAsLocalSystem();                                        // 6

                host.EnableServiceRecovery(service =>                           // 7
                {
                    service.RestartService(3);                                  // 8
                });
                host.SetDescription("Windows service based on topshelf");       // 9
                host.SetDisplayName("Topshelf demo service");                   // 10
                host.SetServiceName("TopshelfDemoService");                     // 11
                host.StartAutomaticallyDelayed();                               // 12
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());       // 13
            Environment.ExitCode = exitCode;
        }
        //Topshelf配置参数说明
        //1.设置服务主机使用HostFactory.Run() 来创建并运行一个Topshelft服务。
        //2.设置Topshelf使用类型HealthMonitorService作为服务类。
        //3.配置如何创建一个服务的实例，这里采用的是使用关键字new来实例化一个HealthMonitorService对象，你也可以使用IoCp容器来实例化服务对象。
        //4.设置当服务启动时执行的操作。
        //5.设置当服务停止时执行的操作。
        //6.设置将服务以本地系统身份运行。
        //7.启动恢复服务模式(当服务意外停止后自动恢复)。
        //8.设置第一次自动恢复服务的延迟时间为3分钟。
        //9.设置Topshelf服务在Windows服务中的描述信息。
        //10.设置Topshelf服务在Windows服务中的显示名称。
        //11.设置Topshelf服务在Windows服务中的服务名称。
        //12.设置Topshelf服务随Windows启动时自动运行(延迟)。
        //13.设置服务的退出代码。
    }
}