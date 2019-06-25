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
using BestQA.QueryService.DTOs;
using BestQA.Repository.Models;

namespace BestQA.Repository
{
    public class AnswerRepository
    {
        /// <summary>
        /// 新增一个回答
        /// </summary>
        /// <param name="answer">The answer.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CreateAnswer(AnswerDTO answer)
        {
            using (var context = new BestQAContext())
            {
                context.Answers.Add(answer);
                context.SaveChanges();
                return true;
            }
        }
    }
}
