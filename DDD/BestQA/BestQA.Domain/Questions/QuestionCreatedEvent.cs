// ***********************************************************************
// Assembly         : BestQA.Domain
// Author           : yubaolee
// Created          : 06-19-2015
//
// Last Modified By : yubaolee
// Last Modified On : 06-19-2015
// ***********************************************************************
// <copyright file="QuestionCreatedEvent.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>领域事件:一个新问题被创建
// </summary>
// ***********************************************************************
using System;
using ENode.Eventing;
namespace BestQA.Domain.Questions
{
    [Serializable]
    public class QuestionCreatedEvent : DomainEvent<string>
    {
        private QuestionCreatedEvent() { }
        public QuestionCreatedEvent(Question question, string title, string content, int reward, string tag, string userid)
            : base(question)
        {
            Title = title;
            Content = content;
            Reward = reward;
            Tag = tag;
            UserId = userid;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Reward { get; set; }
        public string UserId { get; set; }
        public string Tag { get; set; }
    }
}
