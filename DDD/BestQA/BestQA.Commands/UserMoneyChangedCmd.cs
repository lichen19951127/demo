// ***********************************************************************
// Assembly         : BestQA.Commands
// Author           : yubaolee
// Created          : 07-10-2015
//
// Last Modified By : yubaolee
// Last Modified On : 07-10-2015
// ***********************************************************************
// <copyright file="UserMoneyChangedCmd.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>用户积分变更命令</summary>
// ***********************************************************************
using System;
using ENode.Commanding;

namespace BestQA.Commands
{
    [Serializable]
    class UserMoneyChangedCmd :Command<string>
    {
        public string UserId { get; set; }
        /// <summary>
        /// 变化的值，正数为增加，负数为减少
        /// </summary>
        /// <value>The changed value.</value>
        public int ChangedValue { get; set; }

        public UserMoneyChangedCmd(string userId, int changedValue)
        {
            UserId = userId;
            ChangedValue = changedValue;
        }
    }
}
