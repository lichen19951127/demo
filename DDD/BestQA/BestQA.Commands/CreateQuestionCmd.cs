// ***********************************************************************
// Assembly         : BestQA.Commands
// Author           : qinzhi
// Created          : 06-20-2015
//
// Last Modified By : qinzhi
// Last Modified On : 06-23-2015
// ***********************************************************************
// <copyright file="CreateQuestionCmd.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>创建问题命令</summary>
// ***********************************************************************
using System;
using ENode.Commanding;
namespace BestQA.Commands
{
    [Serializable]
    public class CreateQuestionCmd : Command<String>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Reward { get; set; }
        public string UserId { get; set; }
        public string Tag { get; set; }
        private CreateQuestionCmd() { }
        public CreateQuestionCmd(string title, string content, int reward, string tag, string userid)
        {
            Title = title;
            Content = content;
            Reward = reward;
            Tag = tag;
            UserId = userid;
        }
    }
}
