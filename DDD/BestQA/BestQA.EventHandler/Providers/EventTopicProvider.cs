// ***********************************************************************
// Assembly         : 2 BestQA.CommandSubscribe
// Author           : Administrator
// Created          : 06-20-2015
//
// Last Modified By : Administrator
// Last Modified On : 06-22-2015
// ***********************************************************************
// <copyright file="EventTopicProvider.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>初始化领域事件在队列中的消息主题名称</summary>
// ***********************************************************************

using ECommon.Components;
using ENode.EQueue;
using ENode.Eventing;

namespace BestQA.EventHandler.Providers
{
    [Component]
    public class EventTopicProvider : AbstractTopicProvider<IDomainEvent>
    {
        public override string GetTopic(IDomainEvent source)
        {
            return "QuestionEventTopic";
        }
    }
}
