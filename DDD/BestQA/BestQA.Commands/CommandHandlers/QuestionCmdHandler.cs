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
// <summary>问题命令处理</summary>
// ***********************************************************************

using BestQA.Domain.Answers;
using BestQA.Domain.Questions;
using ECommon.Components;
using ECommon.Logging;
using ENode.Commanding;

namespace BestQA.Commands.CommandHandlers
{
    [Component]
    class QuestionCmdHandler :
    ICommandHandler<CreateQuestionCmd>,
    ICommandHandler<ApplyNewAnswerCmd>,
    ICommandHandler<QuestionVoteUpCmd>,
        ICommandHandler<QuestionVoteDownCmd>
    {
        private ILogger _logger;
        public QuestionCmdHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.Create(GetType().Name);
        }
        public void Handle(ICommandContext context, CreateQuestionCmd command)
        {
            context.Add(new Question(
            command.AggregateRootId,
            command.Title,
            command.Content,
            command.Reward,
            command.Tag,
            command.UserId));
            _logger.InfoFormat("Handled {0}, Question Title:{1}", command.GetType().Name, command.Title);
        }
        public void Handle(ICommandContext context, ApplyNewAnswerCmd command)
        {
            _logger.InfoFormat("Handled {0}, Question AnswerId:{1}", command.GetType().Name, command.AnswerId);
            context.Get<Question>(command.AggregateRootId).NewAnswer(context.Get<Answer>(command.AnswerId));
        }
        public void Handle(ICommandContext context, QuestionVoteUpCmd command)
        {
            _logger.InfoFormat("Handled {0}, Question Id:{1}", command.GetType().Name, command.AggregateRootId);
            //todo: 只有在系统运行时添加的新问题才能得到，因为EventStore是存放在内存，需要用数据库解决
            var test = context.Get<Question>(command.Id);

            context.Get<Question>(command.AggregateRootId).SupportedBy(command.UserId);
        }

        public void Handle(ICommandContext context, QuestionVoteDownCmd command)
        {
            _logger.InfoFormat("Handled {0}, Question Id:{1}", command.GetType().Name, command.AggregateRootId);
            context.Get<Question>(command.AggregateRootId).OpposedBy(command.UserId);
        }
    }
}
