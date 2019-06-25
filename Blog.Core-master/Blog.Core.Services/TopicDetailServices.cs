﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Common;
using Blog.Core.IRepository;
using Blog.Core.IServices;
using Blog.Core.Model.Models;
using Blog.Core.Services.BASE;

namespace Blog.Core.Services
{
    public class TopicDetailServices : BaseServices<TopicDetail>, ITopicDetailServices
    {
        ITopicDetailRepository dal;
        public TopicDetailServices(ITopicDetailRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

        /// <summary>
        /// 获取开Bug数据（缓存）
        /// </summary>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 10)]
        public async Task<List<TopicDetail>> GetTopicDetails()
        {
            return await dal.Query(a => !a.tdIsDelete && a.tdSectendDetail == "tbug");
        }
    }
}
