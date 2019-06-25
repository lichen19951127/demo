// ***********************************************************************
// Assembly         : BestQA.Domain
// Author           : yubaolee
// Created          : 06-18-2015
//
// Last Modified By : yubaolee
// Last Modified On : 06-18-2015
// ***********************************************************************
// <copyright file="Question.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>问题类</summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using BestQA.Domain.Answers;
using BestQA.Domain.Model;
using BestQA.Metadata;

namespace BestQA.Domain.Questions
{
    [Serializable]
    public class Question : Post
    {
        /// <summary>
        /// 问题名称
        /// </summary>
        protected string _title;
        /// <summary>
        /// 问题悬赏
        /// </summary>
        private int _reward;
        /// <summary>
        /// 问题的状态
        /// </summary>
        private QuestionState _state;
        /// <summary>
        /// 该问题的回答
        /// </summary>
        private IList<string> _answerIds;
        /// <summary>
        /// 标签
        /// </summary>
        private IList<string> _tagIds;

        public Question(string id, string title, string content, int reward, string tags, string userid)
            :base(id,content, userid)
        {
            ApplyEvent(new QuestionCreatedEvent(this, title,content,reward, tags, userid));
        }
       
        public void NewAnswer(Answer answer)
        {
            if(_answerIds == null)
                _answerIds = new List<string>();
            _answerIds.Add(answer.Id);
        }

        public void ChangeTags(string tags)
        {
            if(_tagIds == null)
                _tagIds = new List<string>();
            _tagIds.Add(tags);
        }

        public override void SendSupportEvent()
        {
            ApplyEvent(new QuestionVoteUpEvent(this, _id));
        }

        public override void SendOpposeEvent()
        {
            ApplyEvent(new QuestionVoteDownEvent(this, _id));
        }

        private void Handle(QuestionCreatedEvent evt)
        {
            _title = evt.Title;
            _content = evt.Content;
            _reward = evt.Reward;
            _userId = evt.UserId;
        }

        private void Handle(QuestionVoteUpEvent evt){}
        private void Handle(QuestionVoteDownEvent evt) { }
    }
}
