﻿using System.Linq;
using System.Net;
using System.Threading;
using BestQA.Commands;
using BestQA.Domain.Answers;
using BestQA.Domain.Questions;
using BestQA.EventHandler;
using BestQA.RegisterExtension;
using ECommon.Components;
using ECommon.Logging;
using ECommon.Scheduling;
using ECommon.Utilities;
using ENode.Commanding;
using ENode.Configurations;
using ENode.EQueue;
using ENode.EQueue.Commanding;
using ENode.Eventing;
using ENode.Infrastructure;
using ENode.Infrastructure.Impl;
using EQueue.Broker;
using EQueue.Configurations;

namespace BestQA.UnitTest
{
    public static class ENodeExtensions
    {
        private static BrokerController _broker;
        private static CommandService _commandService;
        private static CommandConsumer _commandConsumer;
        private static DomainEventPublisher _eventPublisher;
        private static DomainEventConsumer _eventConsumer;
        private static CommandResultProcessor _commandResultProcessor; 

        public static ENodeConfiguration RegisterAllTypeCodes(this ENodeConfiguration enodeConfiguration)
        {
            var provider = ObjectContainer.Resolve<ITypeCodeProvider>() as DefaultTypeCodeProvider;
            provider.RegisterAggregate()
                .RegisterCommand()
                .RegisterEvent()
                .RegisterEventHandler();
          

            return enodeConfiguration;
        }
        public static ENodeConfiguration UseEQueue(this ENodeConfiguration enodeConfiguration)
        {
            var configuration = enodeConfiguration.GetCommonConfiguration();

            configuration.RegisterEQueueComponents();

            _broker = BrokerController.Create();

            _commandResultProcessor = new CommandResultProcessor(new IPEndPoint(SocketUtils.GetLocalIPV4(), 1202));
            _commandService = new CommandService(_commandResultProcessor);
            _eventPublisher = new DomainEventPublisher();

            configuration.SetDefault<ICommandService, CommandService>(_commandService);
            configuration.SetDefault<IMessagePublisher<DomainEventStreamMessage>, DomainEventPublisher>(_eventPublisher);

            //注意，这里实例化之前，需要确保各种MessagePublisher要先注入到IOC，
            // 因为CommandConsumer, DomainEventConsumer都依赖于IMessagePublisher<T>
            _commandConsumer = new CommandConsumer();
            _eventConsumer = new DomainEventConsumer();

            _commandConsumer.Subscribe("QuestionCommandTopic");
            _eventConsumer.Subscribe("QuestionEventTopic");

            return enodeConfiguration;
        }
        public static ENodeConfiguration StartEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _broker.Start();
            _eventConsumer.Start();
            _commandConsumer.Start();
            _eventPublisher.Start();
            _commandService.Start();

            WaitAllConsumerLoadBalanceComplete();

            return enodeConfiguration;
        }

        public static ENodeConfiguration ShutdownEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _commandService.Shutdown();
            _eventPublisher.Shutdown();
            _commandConsumer.Shutdown();
            _eventConsumer.Shutdown();
            _broker.Shutdown();
            return enodeConfiguration;
        }

        private static void WaitAllConsumerLoadBalanceComplete()
        {
            var logger = ObjectContainer.Resolve<ILoggerFactory>().Create(typeof(ENodeExtensions).Name);
            var scheduleService = ObjectContainer.Resolve<IScheduleService>();
            var waitHandle = new ManualResetEvent(false);
            logger.Info("Waiting for all consumer load balance complete, please wait for a moment...");
            var taskId = scheduleService.ScheduleTask("WaitAllConsumerLoadBalanceComplete", () =>
            {
                var eventConsumerAllocatedQueues = _eventConsumer.Consumer.GetCurrentQueues();
                var commandConsumerAllocatedQueues = _commandConsumer.Consumer.GetCurrentQueues();
                if (eventConsumerAllocatedQueues.Count() == 4 && commandConsumerAllocatedQueues.Count() == 4)
                {
                    waitHandle.Set();
                }
            }, 1000, 1000);

            waitHandle.WaitOne();
            scheduleService.ShutdownTask(taskId);
            logger.Info("All consumer load balance completed.");
        }
    }
}