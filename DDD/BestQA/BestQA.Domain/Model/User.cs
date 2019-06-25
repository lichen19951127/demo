// ***********************************************************************
// Assembly         : BestQA.Domain
// Author           : yubaolee
// Created          : 06-18-2015
//
// Last Modified By : yubaolee
// Last Modified On : 06-18-2015
// ***********************************************************************
// <copyright file="User.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>
// 前期设计分为提问人/回答人，现在统一处理为用户，
// 需要处理成聚合，用来维护每个人的园豆（_money）
// </summary>
// ***********************************************************************
using System;
using ENode.Domain;
namespace BestQA.Domain.Model
{
    [Serializable]
    public class User : AggregateRoot<string>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        private string _name;
        /// <summary>
        /// 用户金币
        /// </summary>
        private int _money;
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// 用户的标识与用户名相同
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="money">The money.</param>
        public User(string name, int money)
            : base(name)
        {
            _name = name;
            _money = money;
        }
    }
}
