// ***********************************************************************
// Assembly         : BestQA.Domain
// Author           : yubaolee
// Created          : 06-18-2015
//
// Last Modified By : yubaolee
// Last Modified On : 06-18-2015
// ***********************************************************************
// <copyright file="Post.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>Post类为系统问题、回答、回复的基类</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using BestQA.Domain.Comments;
using ENode.Domain;
using Lee.Infrastructure;

namespace BestQA.Domain.Model
{
    [Serializable]
    public abstract class Post : AggregateRoot<string>
    {
      
        /// <summary>
        /// 内容
        /// </summary>
        protected string _content;
        /// <summary>
        /// 支持数
        /// </summary>
        protected int _supportCnt;
        /// <summary>
        /// 反对数
        /// </summary>
        protected int _opposeCnt;
        /// <summary>
        /// 创建时间
        /// </summary>
        protected DateTime _createTime;
        /// <summary>
        /// 创建人
        /// </summary>
        protected string _userId;
       
        /// <summary>
        /// 评论
        /// </summary>
        protected IList<string> _commentIds; 

        protected Post(string id)
            : base(id)
        {
        }

        protected Post(string id, string content, string userid)
            :base(id)
        {
            _content = content;
            _userId = userid;
            _createTime = DateTime.Now;

        }

        public abstract void SendSupportEvent();
        public void SupportedBy(string userid)
        {
            if (userid == _userId) //自己不能推荐自己
                throw new ApplicationException("自己不能推荐自己");
            _supportCnt++;
            SendSupportEvent();
            
        }

        public abstract void SendOpposeEvent();
        public void OpposedBy(string userid)
        {
            if (userid == _userId) 
                throw new ApplicationException("自己不能反对自己");
            _opposeCnt++;
            SendOpposeEvent();
        }
        public virtual void NewComment(Comment comment)
        {
            Check.IsNotNull("评论", comment);

            if(_commentIds == null)
                _commentIds = new List<string>();

            _commentIds.Add(comment.Id);
        }
    }
}
