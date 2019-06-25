using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Pay.Controllers
{
    public class PayController : Controller
    {
        // GET: Pay
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string partner = "2";
            string subject = context.Request["tbname"];//商品名称
            string body = context.Request["tbms"];       //商品描述
            string out_trade_no = context.Request["tbnum"];//订单号
            string total_fee = context.Request["tbmoney"]; //总金额
            string seller_email = context.Request["tbmail"];//卖家邮箱
            string return_url = "http://localhost:65396/Pay/Index";//回调地址
            string key = "abc123";
            string sign = MD5Encoding(total_fee + partner + out_trade_no + subject + key);
            //重定向到支付的页面
            context.Response.Redirect("http://paytest.rupeng.cn/AliPay/PayGate.ashx?partner=" + partner + "&return_url=" + context.Server.UrlEncode(return_url) + "&subject=" + context.Server.UrlEncode(subject) +
                "&body=" + context.Server.UrlEncode(body) + "&out_trade_no=" + context.Server.UrlEncode(out_trade_no) + "&total_fee=" + total_fee + "&seller_email=" + context.Server.UrlEncode(seller_email)
                + "&sign=" + sign);
            return View();
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string out_trade_no = context.Request["out_trade_no"];//订单号
            string returncode = context.Request["returncode"];       //返回码
            string total_fee = context.Request["total_fee"];//支付金额
            string sign = context.Request["sign"]; //总金额
            if (sign != MD5Encoding(out_trade_no + returncode + total_fee + "abc123"))//防止用户随意篡改数据
            {
                context.Response.Write("数据校验失败");
                return;
            }
            if (returncode == "ok")
            {
                context.Response.Write("支付成功，支付的金额为" + total_fee);
            }
            else
            {
                Console.WriteLine("支付失败");
            }
        }
        /// <summary> 
        /// MD5 加密字符串 
        /// </summary> 
        /// <param name="rawPass">源字符串</param> 
        /// <returns>加密后字符串</returns> 
        private static string MD5Encoding(string rawPass)
        {
            // 创建MD5类的默认实例：MD5CryptoServiceProvider 
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(rawPass);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                // 以十六进制格式格式化 
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}