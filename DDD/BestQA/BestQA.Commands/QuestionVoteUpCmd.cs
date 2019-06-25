// ***********************************************************************
// Assembly         : BestQA.Commands
// Author           : yubaolee
// Created          : 07-21-2015
//
// Last Modified By : yubaolee
// Last Modified On : 07-21-2015
// ***********************************************************************
// <copyright file="VoteUpCmd.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>支持问题</summary>
// ***********************************************************************

using System;
using ENode.Commanding;

namespace BestQA.Commands
{
    [Serializable]
    public class QuestionVoteUpCmd :Command<string>
    {
        public string UserId { get; set; }

        private QuestionVoteUpCmd() { }

        public QuestionVoteUpCmd(string postId, string userid):base(postId)
        {
            UserId = userid;
        }
    }
}
