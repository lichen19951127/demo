using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public static class LogHelper
    {
        public static void WriteLog(string str)
        {
            System.IO.StreamWriter writer = null;
            //写入日志 
            string path = @"F:\ErrorLogs\";
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
        public static void WriteLog(Exception ex)
        {
            System.IO.StreamWriter writer = null;
            //写入日志 
            string path = @"F:\ErrorLogs\";
            //不存在则创建错误日志文件夹
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += string.Format(@"\{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));

            writer = !System.IO.File.Exists(path) ? System.IO.File.CreateText(path) : System.IO.File.AppendText(path); //判断文件是否存在，如果不存在则创建，存在则添加
            writer.WriteLine(ex.Message);
            writer.WriteLine("********************************************************************************************");
        }
    }
}
