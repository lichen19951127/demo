﻿using System;
using System.Timers;

namespace TopshelfDemoService
{
    /// <summary>
    /// 假设为定时监控某个系统的运行健康状况
    /// </summary>
    internal class HealthMonitorService
    {
        private readonly Timer _timer;
        public HealthMonitorService()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("执行系统健康检查任务，所有指标均正常。执行时间：{0}", DateTime.Now);
        }

        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }
    }
}

