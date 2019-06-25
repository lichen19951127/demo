// ***********************************************************************
// Assembly         : BestQA.Domain
// Author           : yubaolee
// Created          : 06-18-2015
//
// Last Modified By : yubaolee
// Last Modified On : 06-18-2015
// ***********************************************************************
// <copyright file="Comment.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>对问题或回答的评论</summary>
// ***********************************************************************

using System;
using BestQA.Domain.Model;

namespace BestQA.Domain.Comments
{
    [Serializable]
    public class Comment : Post
    {
        private string _commentTo;
        public Comment(string id,string content, string userid, string commentto)
            : base(id)
        {
            _content = content;
            _userId = userid;
            _commentTo = commentto;

        }

        public override void SendSupportEvent()
        {
            throw new NotImplementedException();
        }

        public override void SendOpposeEvent()
        {
            throw new NotImplementedException();
        }

        public override void NewComment(Comment comment)
        {
            throw new Exception("不能对评论进行评论");
        }
    }
}
