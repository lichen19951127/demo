using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFSDomain.Common.CoreLib
{

    /// <summary>
    /// 页面信息
    /// </summary>
    public class PageInfo : ViewModelBase
    {
        private string headerName;
        private object body;

        /// <summary>
        /// 标题
        /// </summary>
        public string HeaderName
        {
            get { return headerName; }
            set { headerName = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 窗口内容
        /// </summary>
        public object Body
        {
            get { return body; }
            set { body = value; RaisePropertyChanged(); }
        }
    }
}
