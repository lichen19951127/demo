// ***********************************************************************
// Assembly         : 3 BestQA.EventSubscribe
// Author           : yubaolee
// Created          : 07-10-2015
//
// Last Modified By : yubaolee
// Last Modified On : 07-10-2015
// ***********************************************************************
// <copyright file="AnswerEventHandler.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading.Tasks;
using BestQA.Domain.Answers;
using BestQA.QueryService.DTOs;
using BestQA.Repository;
using ECommon.Components;
using ECommon.IO;
using ECommon.Logging;
using ENode.Commanding;
using ENode.Infrastructure;

namespace BestQA.EventHandler
{
    [Component]
    public class AnswerEventHandler : IMessageHandler<AnswerCreatedEvent>
    {
        private ILogger _logger;
        private ICommandService _commandService;
        public AnswerEventHandler(ILoggerFactory loggerFactory, ICommandService service)
        {
            _logger = loggerFactory.Create(typeof(AnswerEventHandler).Name);
            _commandService = service;
        }
        public Task<AsyncTaskResult> HandleAsync(AnswerCreatedEvent evnt)
        {
            _logger.InfoFormat(" event:{0},Answer content:{1}", this.GetType().Name, evnt.Content);
            var answer = new AnswerDTO
            {
                Content = evnt.Content,
                CreatedTime = DateTime.Now,
                Id = evnt.AggregateRootId,
                UserId = evnt.UserId,
                AnswerTo = evnt.AnswerTo
                
            };
            var repository = new AnswerRepository();
            repository.CreateAnswer(answer);
            return Task.FromResult(AsyncTaskResult.Success);
        }
    }
}
