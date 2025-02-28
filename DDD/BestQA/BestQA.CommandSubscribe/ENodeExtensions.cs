﻿using System.Linq;
using System.Threading;
using BestQA.RegisterExtension;
using ECommon.Components;
using ECommon.Logging;
using ECommon.Scheduling;
using ENode.Configurations;
using ENode.EQueue;
using ENode.Eventing;
using ENode.Infrastructure;
using ENode.Infrastructure.Impl;
using EQueue.Configurations;

namespace BestQA.CommandSubscribe
{
    public static class ENodeExtensions
    {
        private static CommandConsumer _commandConsumer;
        private static DomainEventPublisher _domainEventPublisher;

        public static ENodeConfiguration UseEQueue(this ENodeConfiguration enodeConfiguration)
        {
            var configuration = enodeConfiguration.GetCommonConfiguration();
            configuration.RegisterEQueueComponents();
            _domainEventPublisher = new DomainEventPublisher();
            configuration.SetDefault<IMessagePublisher<DomainEventStreamMessage>, DomainEventPublisher>(_domainEventPublisher);

            _commandConsumer = new CommandConsumer();
            _commandConsumer.Subscribe("QuestionCommandTopic");

            return enodeConfiguration;
        }
        public static ENodeConfiguration StartEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _commandConsumer.Start();
            _domainEventPublisher.Start();

            WaitAllConsumerLoadBalanceComplete();

            return enodeConfiguration;
        }

        public static ENodeConfiguration RegisterAllTypeCodes(this ENodeConfiguration enodeConfiguration)
        {
            var provider = ObjectContainer.Resolve<ITypeCodeProvider>() as DefaultTypeCodeProvider;

            provider.RegisterAggregate()
                .RegisterCommand()
                .RegisterEvent();

            return enodeConfiguration;
        }

        private static void WaitAllConsumerLoadBalanceComplete()
        {
            var logger = ObjectContainer.Resolve<ILoggerFactory>().Create(typeof(ENodeExtensions).Name);
            var scheduleService = ObjectContainer.Resolve<IScheduleService>();
            var waitHandle = new ManualResetEvent(false);
            logger.Info("等待所有负载加载...");
            var taskId = scheduleService.ScheduleTask("WaitAllConsumerLoadBalanceComplete", () =>
            {
                var commandConsumerAllocatedQueues = _commandConsumer.Consumer.GetCurrentQueues();
                if (commandConsumerAllocatedQueues.Count() == 8)
                {
                    waitHandle.Set();
                }
            }, 1000, 1000);

            waitHandle.WaitOne();
            scheduleService.ShutdownTask(taskId);
            logger.Info("加载完成");
        }
    }
}
