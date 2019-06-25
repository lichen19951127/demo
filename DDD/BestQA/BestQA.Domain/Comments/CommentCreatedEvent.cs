// ***********************************************************************
// Assembly         : BestQA.Domain
// Author           : yubaolee
// Created          : 07-10-2015
//
// Last Modified By : yubaolee
// Last Modified On : 07-10-2015
// ***********************************************************************
// <copyright file="CommentCreatedEvent.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>添加新评论</summary>
// ***********************************************************************
using System;
using ENode.Eventing;

namespace BestQA.Domain.Comments
{
    [Serializable]
    public class CommentCreatedEvent : DomainEvent<string>
    {
        public string CommentTo { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }

        private CommentCreatedEvent() { }

        public CommentCreatedEvent(Comment comment,string content, string commentto, string userid):base(comment)
        {
            CommentTo = commentto;
            Content = content;
            UserId = userid;
        }
    }
}
