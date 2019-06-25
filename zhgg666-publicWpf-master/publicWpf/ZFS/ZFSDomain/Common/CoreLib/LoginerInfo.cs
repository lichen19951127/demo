using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFSDomain.Common.CoreLib
{
    /// <summary>
    ///  系统显示个人信息面板
    /// </summary>
    public class LoginerInfo
    {
        public string Icon { get; set; } = "Lastfm";

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; } = "ZFS.Framework";

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Account { get; set; }

    }
}
