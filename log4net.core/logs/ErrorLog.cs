using System;
using System.IO;

namespace logs
{
    public class ErrorLog
    {
        public static void WriteLog(Exception ex)
        {
            //读取二级
            var logsPath=AppConfigurtaionServices.Configuration["Path:LogsPath"];

            string errorTime = "异常时间：" + DateTime.Now.ToString();
            string errorAddress = "异常地址：" + HttpContext.Current.Request.Scheme.ToString()+"://"+ HttpContext.Current.Request.Host.ToString()+ HttpContext.Current.Request.Path.ToString();
            string errorInfo = "异常信息：" + ex.Message;
            string errorSource = "错误源：" + ex.Source;
            string errorType = "运行类型：" + ex.GetType();
            string errorFunction = "异常函数：" + ex.TargetSite;
            string errorTrace = "堆栈信息：" + ex.StackTrace;
         
            //HttpContext.Current.Server.ClearError();
            System.IO.StreamWriter writer = null;
            try
            {
                //写入日志 
                string path = string.Empty;
               path= System.AppDomain.CurrentDomain.BaseDirectory.ToString()+ logsPath;
                //path = HttpContext.Current.Server.MapPath("~/ErrorLogs/");
                //不存在则创建错误日志文件夹
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += string.Format(@"\{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));

                writer = !System.IO.File.Exists(path) ? System.IO.File.CreateText(path) : System.IO.File.AppendText(path); //判断文件是否存在，如果不存在则创建，存在则添加
                writer.WriteLine("用户IP:" + HttpContext.Current.Connection.RemoteIpAddress.ToString());
                writer.WriteLine(errorTime);
                writer.WriteLine(errorAddress);
                writer.WriteLine(errorInfo);
                writer.WriteLine(errorSource);
                writer.WriteLine(errorType);
                writer.WriteLine(errorFunction);
                writer.WriteLine(errorTrace);
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