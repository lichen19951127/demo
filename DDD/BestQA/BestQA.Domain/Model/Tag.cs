// ***********************************************************************
// Assembly         : BestQA.Domain
// Author           : yubaolee
// Created          : 06-18-2015
//
// Last Modified By : yubaolee
// Last Modified On : 06-18-2015
// ***********************************************************************
// <copyright file="Tag.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>问题标签，设计成一个聚合，用户可以直接查找热门标签</summary>
// ***********************************************************************

using System;
using ENode.Domain;

namespace BestQA.Domain.Model
{
    [Serializable]
    public class Tag : AggregateRoot<string>
    {
        private string _name;

        public string Name
        {
            get { return _name;}
        }

        public Tag(string id, string name) : base(id)
        {
            _name = name;
        }
    }
}