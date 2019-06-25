// ***********************************************************************
// Assembly         : BestQA.RegisterExtension
// Author           : Administrator
// Created          : 07-23-2015
//
// Last Modified By : Administrator
// Last Modified On : 07-23-2015
// ***********************************************************************
// <copyright file="RegisterTypeExtension.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>该文件统一处理命令定义，省得在N个项目中定义</summary>
// ***********************************************************************

using BestQA.Commands;
using BestQA.Domain.Answers;
using BestQA.Domain.Questions;
using BestQA.EventHandler;
using ENode.Infrastructure.Impl;

namespace BestQA.RegisterExtension
{
    public static class RegisterTypeExtension
    {
        public static DefaultTypeCodeProvider RegisterAggregate(this DefaultTypeCodeProvider provider)
        {
            //aggregates
            provider.RegisterType<Question>(1000);
            provider.RegisterType<Answer>(1001);
            return provider;
        }

        public static DefaultTypeCodeProvider RegisterCommand(this DefaultTypeCodeProvider provider)
        {
            provider.RegisterType<CreateQuestionCmd>(2000);
            provider.RegisterType<CreateAnswerCmd>(2001);
            provider.RegisterType<ApplyNewAnswerCmd>(2002);
            provider.RegisterType<QuestionVoteUpCmd>(2003);
            provider.RegisterType<QuestionVoteDownCmd>(2004);
            return provider;
        }


        public static DefaultTypeCodeProvider RegisterEvent(this DefaultTypeCodeProvider provider)
        {
            provider.RegisterType<QuestionCreatedEvent>(3000);
            provider.RegisterType<AnswerCreatedEvent>(3001);
            provider.RegisterType<QuestionVoteUpEvent>(3002);
            provider.RegisterType<QuestionVoteDownEvent>(3003);
            return provider;
        }

        public static DefaultTypeCodeProvider RegisterEventHandler(this DefaultTypeCodeProvider provider)
        {
            provider.RegisterType<QuestionEventHandler>(4000);
            provider.RegisterType<AnswerEventHandler>(4001);
            return provider;
        }
    }
}
