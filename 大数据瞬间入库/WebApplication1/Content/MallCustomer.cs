using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WebApplication1.Content
{
    ///<summary>
    ///客户主表
    ///</summary>
    public partial class MallCustomer
    {
        public MallCustomer()
        {


        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Desc:公司名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Company { get; set; }

        /// <summary>
        /// Desc:注册地址
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Address { get; set; }

        /// <summary>
        /// Desc:公司营业范围
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Business { get; set; }

        /// <summary>
        /// Desc:注册资金
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public decimal? RegCapital { get; set; }

        /// <summary>
        /// Desc:投保人数
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? EmployeesNum { get; set; }

        /// <summary>
        /// Desc:法人
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Boss { get; set; }

        /// <summary>
        /// Desc:客户状态 10:公池20:认领待审批21:认领失败22:认领成功
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public MallCustomerStates Status { get; set; }

        /// <summary>
        /// Desc:状态变更时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? StatusTime { get; set; }

        /// <summary>
        /// Desc:客户类型 10:潜在意向客户20:意向客户30:成交用户
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public MallCustomerType Type { get; set; }

        /// <summary>
        /// Desc:类型变更时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? TypeTime { get; set; }

        /// <summary>
        /// Desc:ABC
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Level { get; set; }

        /// <summary>
        /// Desc:预采购额
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public decimal PrePurchase { get; set; }

        /// <summary>
        /// Desc:采购模式描述
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Description { get; set; }

        /// <summary>
        /// Desc:销售编号
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int YewuId { get; set; }

        /// <summary>
        /// Desc:销售名称
        /// Default:
        /// Nullable:False
        /// </summary>        
        public string YewuName { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDel { get; set; }

        /// <summary>
        /// Desc:备注
        /// Default:
        /// Nullable:False
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public DateTime Createtime { get; set; }

    }

    /// <summary>
    /// 客户状态
    /// </summary>
    public enum MallCustomerStates
    {
        公池 = 10,
        认领待审批 = 20,
        认领失败 = 21,
        认领成功 = 22
    }

    /// <summary>
    /// 客户类型
    /// </summary>
    public enum MallCustomerType
    {
        潜在意向客户 = 10,
        意向客户 = 20,
        成交用户 = 30
    }

    public class MallCustomerLevel
    {
        public const string A = "A";
        public const string B = "B";
        public const string C = "C";
    }
}
