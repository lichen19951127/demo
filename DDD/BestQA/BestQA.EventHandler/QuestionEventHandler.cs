// ***********************************************************************
// Assembly         : 3 BestQA.EventSubscribe
// Author           : Administrator
// Created          : 06-20-2015
//
// Last Modified By : Administrator
// Last Modified On : 06-20-2015
// ***********************************************************************
// <copyright file="QuestionEventHandler.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>创建问题领域事件处理程序</summary>
// ***********************************************************************

using System;
using System.Threading.Tasks;
using BestQA.Domain.Questions;
using BestQA.QueryService.DTOs;
using BestQA.Repository;
using ECommon.Components;
using ECommon.IO;
using ECommon.Logging;
using ENode.Infrastructure;

namespace BestQA.EventHandler
{
    [Component]
    public class QuestionEventHandler :
        IMessageHandler<QuestionCreatedEvent>,
        IMessageHandler<QuestionVoteUpEvent>,
        IMessageHandler<QuestionVoteDownEvent>
    {
        private ILogger _logger;
        public QuestionEventHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.Create(typeof(QuestionEventHandler).Name);
        }
        public Task<AsyncTaskResult> HandleAsync(QuestionCreatedEvent evnt)
        {
            _logger.InfoFormat(" event:{0},Question title:{1}", evnt.GetType().Name, evnt.Title);
            var question = new QuestionDTO
            {
                Title = evnt.Title,
                Content = evnt.Content,
                CreatedTime = DateTime.Now,
                Id = evnt.AggregateRootId,
                UserId = evnt.UserId
            };
            var repository = new QuestionRepository();
            repository.CreateQuestion(question);
            return Task.FromResult(AsyncTaskResult.Success);
        }

        public Task<AsyncTaskResult> HandleAsync(QuestionVoteUpEvent evnt)
        {
            _logger.InfoFormat(" event:{0},Question Id:{1}", evnt.GetType().Name, evnt.PostId);
            var repository = new QuestionRepository();
            repository.Support(evnt.PostId);
            return Task.FromResult(AsyncTaskResult.Success);
        }

        public Task<AsyncTaskResult> HandleAsync(QuestionVoteDownEvent evnt)
        {
            _logger.InfoFormat(" event:{0},Question Id:{1}", evnt.GetType().Name, evnt.PostId);
            var repository = new QuestionRepository();
            repository.Oppose(evnt.PostId);
            return Task.FromResult(AsyncTaskResult.Success);
        }
    }
}
