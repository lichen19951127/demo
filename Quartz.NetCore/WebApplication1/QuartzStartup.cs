using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    using IOCContainer = IServiceProvider;
    // Quartz.Net启动后注册job和trigger
    public class QuartzStartup
    {
        public IScheduler _scheduler { get; set; }

        private readonly ILogger _logger;
        private readonly IJobFactory iocJobfactory;
        public QuartzStartup(IOCContainer IocContainer, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<QuartzStartup>();
            iocJobfactory = new IOCJobFactory(IocContainer);
            var schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler().Result;
            _scheduler.JobFactory = iocJobfactory;
        }

        public void Start()
        {
            _logger.LogInformation("Schedule job load as application start.");
            _scheduler.Start().Wait();

            var UsageCounterSyncJob = JobBuilder.Create<UsageCounterSyncJob>()
               .WithIdentity("UsageCounterSyncJob")
               .Build();

            var UsageCounterSyncJobTrigger = TriggerBuilder.Create()
                .WithIdentity("UsageCounterSyncCron")
                .StartNow()
                // 每隔一小时同步一次
                //.WithCronSchedule("0 * * * * ?")
                //每3秒
                //.WithCronSchedule("0/3 * * * * ?")
                //每5秒
                .WithCronSchedule("0/5 * * * * ?")      // Seconds,Minutes,Hours，Day-of-Month，Month，Day-of-Week，Year（optional field）
                .Build();
            _scheduler.ScheduleJob(UsageCounterSyncJob, UsageCounterSyncJobTrigger).Wait();

            _scheduler.TriggerJob(new JobKey("UsageCounterSyncJob"));
        }

        public void Stop()
        {
            if (_scheduler == null)
            {
                return;
            }

            if (_scheduler.Shutdown(waitForJobsToComplete: true).Wait(30000))
                _scheduler = null;
            else
            {
            }
            _logger.LogCritical("Schedule job upload as application stopped");
        }
    }

    /// <summary>
    /// IOCJobFactory ：实现在Timer触发的时候注入生成对应的Job组件
    /// </summary>
    public class IOCJobFactory : IJobFactory
    {
        protected readonly IOCContainer Container;

        public IOCJobFactory(IOCContainer container)
        {
            Container = container;
        }

        //Called by the scheduler at the time of the trigger firing, in order to produce
        //     a Quartz.IJob instance on which to call Execute.
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return Container.GetService(bundle.JobDetail.JobType) as IJob;
        }

        // Allows the job factory to destroy/cleanup the job if needed.
        public void ReturnJob(IJob job)
        {
        }
    }
}
