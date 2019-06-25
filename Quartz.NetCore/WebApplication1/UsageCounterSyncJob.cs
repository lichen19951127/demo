using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class UsageCounterSyncJob : IJob
    {
        private readonly ILogger _logger;
        public UsageCounterSyncJob(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<UsageCounterSyncJob>();
        }
        public async Task Execute(IJobExecutionContext context)
        {
            // 触发时间在凌晨，则同步昨天的计数
            var _day = DateTime.Now.ToString("yyyyMMdd");
            if (context.FireTimeUtc.LocalDateTime.Hour == 0)
                _day = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");

            _logger.LogInformation("[UsageCounterSyncJob] Schedule job executed.");
            LogHelpr.Info("[UsageCounterSyncJob] Schedule job executed."+DateTime.Now.ToString());
        }
 }
}
