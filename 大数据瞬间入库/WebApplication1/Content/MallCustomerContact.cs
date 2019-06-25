using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WebApplication1.Content
{
    ///<summary>
    ///客户联系人表
    ///</summary>
    public partial class MallCustomerContact
    {
        public MallCustomerContact()
        {
            Name = "";
            Mobile = "";
            Weixin = "";
            QQ = "";
            Job = "";
            Remark = "";
            IsDel = false;
            Createtime = DateTime.Now;
        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>     
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Desc:客户编号
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int CustomerId { get; set; }

        /// <summary>
        /// Desc:联系人
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// Desc:手机/电话
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Mobile { get; set; }

        /// <summary>
        /// Desc:微信
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Weixin { get; set; }

        /// <summary>
        /// Desc:QQ
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string QQ { get; set; }

        /// <summary>
        /// Desc:职务
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Job { get; set; }

        /// <summary>
        /// Desc:备注
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Remark { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime Createtime { get; set; }

    }
}
