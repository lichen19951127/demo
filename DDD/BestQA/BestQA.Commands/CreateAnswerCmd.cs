// ***********************************************************************
// Assembly         : BestQA.Commands
// Author           : yubaolee
// Created          : 07-10-2015
//
// Last Modified By : yubaolee
// Last Modified On : 07-10-2015
// ***********************************************************************
// <copyright file="CreateAnswerCmd.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>创建回答命令</summary>
// ***********************************************************************

using System;
using ENode.Commanding;

namespace BestQA.Commands
{
    [Serializable]
    public class CreateAnswerCmd :Command<String>
    {
        public CreateAnswerCmd(string content, string userid, string answerto)
        {
            Content = content;
            UserId = userid;
            AnswerTo = answerto;
        }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string AnswerTo { get; set; }
        
    }
}
