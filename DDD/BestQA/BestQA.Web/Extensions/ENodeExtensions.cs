// ***********************************************************************
// Assembly         : BestQA.Web
// Author           : Administrator
// Created          : 06-22-2015
//
// Last Modified By : Administrator
// Last Modified On : 06-22-2015
// ***********************************************************************
// <copyright file="ENodeExtensions.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>ENode扩展文件</summary>
// ***********************************************************************
using System.Net;
using BestQA.Commands;
using BestQA.RegisterExtension;
using ECommon.Components;
using ECommon.Utilities;
using ENode.Commanding;
using ENode.Configurations;
using ENode.EQueue;
using ENode.EQueue.Commanding;
using ENode.Infrastructure;
using ENode.Infrastructure.Impl;
using EQueue.Configurations;

namespace BestQA.Web.Extensions
{
    public static class ENodeExtensions
    {
        private static CommandService _commandService;
        private static CommandResultProcessor _commandResultProcessor;

        /// <summary>
        /// 注册默认的消息处理
        /// </summary>
        public static ENodeConfiguration UseEQueue(this ENodeConfiguration enodeConfiguration)
        {
            var configuration = enodeConfiguration.GetCommonConfiguration();

            configuration.RegisterEQueueComponents();

            _commandResultProcessor = new CommandResultProcessor(new IPEndPoint(SocketUtils.GetLocalIPV4(), 1202));
            _commandService = new CommandService(_commandResultProcessor);

            configuration.SetDefault<ICommandService, CommandService>(_commandService);

            return enodeConfiguration;
        }
        /// <summary>
        /// 启动命令服务
        /// </summary>
        public static ENodeConfiguration StartEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _commandService.Start();
            return enodeConfiguration;
        }

        /// <summary>
        /// 注册WEB中使用的命令
        /// </summary>
        public static ENodeConfiguration RegisterAllTypeCodes(this ENodeConfiguration enodeConfiguration)
        {
            var provider = ObjectContainer.Resolve<ITypeCodeProvider>() as DefaultTypeCodeProvider;

            provider.RegisterCommand();

            return enodeConfiguration;
        }
    }
}
