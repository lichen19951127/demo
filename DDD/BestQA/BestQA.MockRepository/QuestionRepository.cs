// ***********************************************************************
// Assembly         : BestQA.Repository
// Author           : qinzhi
// Created          : 06-23-2015
//
// Last Modified By : qinzhi
// Last Modified On : 06-23-2015
// ***********************************************************************
// <copyright file="QuestionRepository.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>问题领域事件序列化</summary>
// ***********************************************************************

using System.Linq;
using BestQA.QueryService.DTOs;
using BestQA.Repository.Models;

namespace BestQA.Repository
{
    public class QuestionRepository
    {
        /// <summary>
        /// 创建一个新问题
        /// </summary>
        /// <param name="question">The question.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CreateQuestion(QuestionDTO question)
        {
            using (var context = new BestQAContext())
            {
                context.Questions.Add(question);
                context.SaveChanges();
                return true;
            }
        }

        public bool Support(string postid)
        {
            using (var context = new BestQAContext())
            {
                var question = context.Questions.SingleOrDefault(q => q.Id == postid);
                if (question != null)
                {
                    question.SupportCnt++;
                    context.SaveChanges();
                }
                return true;
            }
        }

        public bool Oppose(string postid)
        {
            using (var context = new BestQAContext())
            {
                var question = context.Questions.SingleOrDefault(q => q.Id == postid);
                if (question != null)
                {
                    question.OpposeCnt++;
                    context.SaveChanges();
                }
                return true;
            }
        }
    }
}
