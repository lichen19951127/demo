using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace BYRotativa.AspNetCore.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return new ViewAsPdf("Index");
        }

        public IActionResult Test()
        {
            //var report = new ViewAsPdf("Index",model数据)
            //{
            //    PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
            //};
            var report = new ViewAsPdf("Index")
            {
                PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
            };
            return report;
        }

        public IActionResult TestByJS()
        {
            List<int> list = new List<int>() { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30};
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public void SavePDF(string str)
        {
            string base64 = DecodeBase64(str);
            Base64StringToFile(str, @"F:\test\aaa.pdf");

        }
        public void Base64StringToFile(string strbase64, string strurl)
        {
            try
            {
                strbase64 = strbase64.Replace(' ', '+');
                MemoryStream stream = new MemoryStream(Convert.FromBase64String(strbase64));
                FileStream fs = new FileStream(strurl, FileMode.OpenOrCreate, FileAccess.Write);
                byte[] b = stream.ToArray();
                //byte[] b = stream.GetBuffer();
                fs.Write(b, 0, b.Length);
                fs.Close();

            }
            catch (Exception e)
            {

            }
        }
        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="codeName">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(Encoding encode, string result)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(string result)
        {
            return DecodeBase64(Encoding.UTF8, result);
        }
    }
}