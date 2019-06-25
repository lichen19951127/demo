// ***********************************************************************
// Assembly         : 1 BestQA.MessageQueue
// Author           : Administrator
// Created          : 06-20-2015
//
// Last Modified By : Administrator
// Last Modified On : 06-20-2015
// ***********************************************************************
// <copyright file="Program.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>启动消息队列，本队列使用内存队列</summary>
// ***********************************************************************
using System;
using ECommon.Autofac;
using ECommon.Components;
using ECommon.Configurations;
using ECommon.JsonNet;
using ECommon.Log4Net;
using ECommon.Logging;
using EQueue.Broker;
using EQueue.Configurations;

namespace BestQA.MessageQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeEQueue();
            BrokerController.Create().Start();

            ObjectContainer.Resolve<ILoggerFactory>().Create(typeof(Program).Name).Info("Broker started, press Enter to exit...");
            Console.ReadLine();
        }

        static void InitializeEQueue()
        {
            Configuration
                .Create()
                .UseAutofac()
                .RegisterCommonComponents()
                .UseLog4Net()
                .UseJsonNet()
                .RegisterEQueueComponents();
        }
    }
}
