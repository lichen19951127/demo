// ***********************************************************************
// Assembly         : BestQA.Domain
// Author           : yubaolee
// Created          : 06-18-2015
//
// Last Modified By : yubaolee
// Last Modified On : 06-18-2015
// ***********************************************************************
// <copyright file="Answer.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>问题的回答类</summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using BestQA.Domain.Model;

namespace BestQA.Domain.Answers
{
    [Serializable]
    public class Answer : Post
    {
        private int _award;
        private string _answerTo;
        private IList<AnswerState> _states;
        public Answer(string id,string content,string userid,string answerto) : base(id,content,userid)
        {
            ApplyEvent(new AnswerCreatedEvent(this, content, answerto, userid));
        }

        private void Handle(AnswerCreatedEvent evt)
        {
            _content = evt.Content;
            _answerTo = evt.AnswerTo;
        }

        public override void SendSupportEvent()
        {
            throw new NotImplementedException();
        }

        public override void SendOpposeEvent()
        {
            throw new NotImplementedException();
        }
    }
}
