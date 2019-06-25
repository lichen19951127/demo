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
// <summary>Post��Ϊϵͳ���⡢�ش𡢻ظ��Ļ���</summary>
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
        /// ����
        /// </summary>
        protected string _content;
        /// <summary>
        /// ֧����
        /// </summary>
        protected int _supportCnt;
        /// <summary>
        /// ������
        /// </summary>
        protected int _opposeCnt;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        protected DateTime _createTime;
        /// <summary>
        /// ������
        /// </summary>
        protected string _userId;
       
        /// <summary>
        /// ����
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
            if (userid == _userId) //�Լ������Ƽ��Լ�
                throw new ApplicationException("�Լ������Ƽ��Լ�");
            _supportCnt++;
            SendSupportEvent();
            
        }

        public abstract void SendOpposeEvent();
        public void OpposedBy(string userid)
        {
            if (userid == _userId) 
                throw new ApplicationException("�Լ����ܷ����Լ�");
            _opposeCnt++;
            SendOpposeEvent();
        }
        public virtual void NewComment(Comment comment)
        {
            Check.IsNotNull("����", comment);

            if(_commentIds == null)
                _commentIds = new List<string>();

            _commentIds.Add(comment.Id);
        }
    }
}
