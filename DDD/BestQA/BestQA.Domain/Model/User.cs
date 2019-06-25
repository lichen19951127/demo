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
// ǰ����Ʒ�Ϊ������/�ش��ˣ�����ͳһ����Ϊ�û���
// ��Ҫ����ɾۺϣ�����ά��ÿ���˵�԰����_money��
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
        /// �û���
        /// </summary>
        private string _name;
        /// <summary>
        /// �û����
        /// </summary>
        private int _money;
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// �û��ı�ʶ���û�����ͬ
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
