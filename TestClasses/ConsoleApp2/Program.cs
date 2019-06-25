using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            MallPayment pay = new MallPayment();
            payment.InvoicedTime = DateTime.Now;
            payment.InvoiceNo = invoiceNO;
            pay.CreateDate = DateTime.Now;
            pay.Invoiced = OrderInvoiceStatus.已确认收票;
            pay.NextDate = DateTime.Now;
            pay.OriDate = DateTime.Now;//账期计算 不存在账期  可能来自销售设置回款日期
            pay.Remarks = "";
            pay.TotalPrice = 0;//计算售价
            pay.Type = 1;
            pay.UpdateDate = DateTime.Now;
        }
    }

    public class MallPayment
    {
        public MallPayment()
        {
            this.CreateDate = DateTime.Now;
            this.InvoicedTime = DateTime.Now;
            Remarks = "";
            InvoiceNo = "";
        }
        /// <summary>
        /// 主键ID
        /// </summary>  
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 原始应收/应付日期
        /// </summary>        
        public DateTime OriDate { get; set; }

        /// <summary>
        /// 应收/应付下次的日期，默认为原始日期
        /// </summary>        
        public DateTime NextDate { get; set; }

        /// <summary>
        /// 已支付/收款总金额
        /// </summary>        
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 开票状态，待认证 = 0,待开票 = 1,待寄出 = 2,待用户签收 = 3,已完成 = 4,已申请开票=5,已确认收票=6
        /// </summary>        
        public OrderInvoiceStatus Invoiced { get; set; }

        /// <summary>
        /// 发票编号
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// 开/收票时间
        /// </summary>
        public DateTime? InvoicedTime { get; set; }

        /// <summary>
        /// 类型:1应付 2应收
        /// </summary>        
        public int Type { get; set; }

        /// <summary>
        /// 备注，json格式:[{name:'',content:'',time:''}]
        /// </summary>        
        public string Remarks { get; set; }

        /// <summary>
        /// 更改时间
        /// </summary>        
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>        
        public DateTime CreateDate { get; set; }


    }
}
