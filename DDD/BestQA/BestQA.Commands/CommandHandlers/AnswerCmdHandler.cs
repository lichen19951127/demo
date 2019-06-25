// ***********************************************************************
// Assembly         : 2 BestQA.CommandSubscribe
// Author           : Administrator
// Created          : 06-20-2015
//
// Last Modified By : Administrator
// Last Modified On : 06-22-2015
// ***********************************************************************
// <copyright file="CreateQuestionCmdHandler.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>创建问题命令处理</summary>
// ***********************************************************************

using BestQA.Domain.Answers;
using ECommon.Components;
using ECommon.Logging;
using ENode.Commanding;

namespace BestQA.Commands.CommandHandlers
{
    [Component]
    class AnswerCmdHandler : ICommandHandler<CreateAnswerCmd>
    {
        private ILogger _logger;

        public AnswerCmdHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.Create(GetType().Name);
        }

        public void Handle(ICommandContext context, CreateAnswerCmd command)
        {
            context.Add(new Answer(
                command.AggregateRootId,
                command.Content, 
                command.UserId,
                command.AnswerTo));
            _logger.InfoFormat("Handled {0}, Answer Content:{1}", typeof(CreateAnswerCmd).Name, command.Content);
        }
    }
}
