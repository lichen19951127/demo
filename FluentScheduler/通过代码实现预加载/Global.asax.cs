using FluentScheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace 通过代码实现预加载
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //启用
            JobManager.Initialize(new MyJob());
        }

        protected void Application_End()
        {
            WriteLog("进程即将被IIS回收"+DateTime.Now);
            WriteLog("重新访问一个页面,以唤醒服务" + DateTime.Now);
            string strURL = System.Configuration.ConfigurationManager.AppSettings["homeURL"].ToString();
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                System.IO.Stream stream = wc.OpenRead(strURL);
                System.IO.StreamReader reader = new StreamReader(stream);
                string html = reader.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(html))
                {
                    WriteLog("唤醒程序成功" + DateTime.Now);
                }
                reader.Close();
                reader.Dispose();
                stream.Close();
                stream.Dispose();
                wc.Dispose();
            }
            catch (Exception ex)
            {
                WriteLog("唤醒异常"+ex.Message+DateTime.Now);
            }
        }

        public void WriteLog(string str)
        {
            System.IO.StreamWriter writer = null;
            try
            {
                //写入日志 
                string path = string.Empty;
                path = @"F:\ErrorLogs\";
                //不存在则创建错误日志文件夹
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += string.Format(@"\{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));

                writer = !System.IO.File.Exists(path) ? System.IO.File.CreateText(path) : System.IO.File.AppendText(path); //判断文件是否存在，如果不存在则创建，存在则添加
                writer.WriteLine(str);
                writer.WriteLine("********************************************************************************************");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
