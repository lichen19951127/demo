// ***********************************************************************
// Assembly         : BestQA.QueryService
// Author           : qinzhi
// Created          : 06-22-2015
//
// Last Modified By : qinzhi
// Last Modified On : 06-23-2015
// ***********************************************************************
// <copyright file="IQuestionQuery.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using BestQA.QueryService.DTOs;

namespace BestQA.QueryService
{
    public interface IQuestionQuery
    {
        /// <summary>
        /// 查找指定的问题
        /// </summary>
        /// <param name="id">问题的标识</param>
        /// <returns>QuestionDTO.</returns>
        QuestionDTO Find(string id);
        /// <summary>
        /// 加载所有问题
        /// </summary>
        IEnumerable<QuestionDTO> FindAll();
    }
}
