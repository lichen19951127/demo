// ***********************************************************************
// Assembly         : BestQA.Commands
// Author           : yubaolee
// Created          : 07-24-2015
//
// Last Modified By : yubaolee
// Last Modified On : 07-24-2015
// ***********************************************************************
// <copyright file="QuestionVoteDownCmd.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>反对问题</summary>
// ***********************************************************************

using System;
using ENode.Commanding;

namespace BestQA.Commands
{
    [Serializable]
    public class QuestionVoteDownCmd :Command<string>
    {
        public string UserId { get; set; }

        private QuestionVoteDownCmd() { }

        public QuestionVoteDownCmd(string postId, string userid)
            : base(postId)
        {
            UserId = userid;
        }
    }
}
