// ***********************************************************************
// Assembly         : BestQA.Domain
// Author           : yubaolee
// Created          : 07-10-2015
//
// Last Modified By : yubaolee
// Last Modified On : 07-10-2015
// ***********************************************************************
// <copyright file="AnswerCreatedEvent.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>创建回答</summary>
// ***********************************************************************

using System;
using ENode.Eventing;

namespace BestQA.Domain.Answers
{
    [Serializable]
    public class AnswerCreatedEvent : DomainEvent<string>
    {
        public string AnswerTo { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }

        private AnswerCreatedEvent() { }

        public AnswerCreatedEvent(Answer answer, string content, string answerto, string userid)
            : base(answer)
        {
            AnswerTo = answerto;
            Content = content;
            UserId = userid;
        }
    }
}
