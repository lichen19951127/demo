using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 通过代码实现预加载
{
    using FluentScheduler;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    public class MyJob : Registry
    {
        public MyJob()
        {
            // 每2秒一次循环
            Schedule<MyJob1>().ToRunNow().AndEvery(2).Seconds();

            // 5秒后，只一次
            Schedule<MyOtherJob>().ToRunOnceIn(5).Seconds();

            //每天晚上21：15分执行
            Schedule(() => Console.WriteLine("Timed Task - Will run every day at 9:15pm: " + DateTime.Now)).ToRunEvery(1).Days().At(21, 15);

            // 每个月的执行
            Schedule(() =>
            {
                Console.WriteLine("Complex Action Task Starts: " + DateTime.Now);
                Thread.Sleep(1000);
                Console.WriteLine("Complex Action Task Ends: " + DateTime.Now);
            }).ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Monday).At(3, 0);

            Schedule(() =>
            {
                Console.WriteLine("Complex Action Task Starts: " + DateTime.Now);
                Thread.Sleep(1000);
                Console.WriteLine("Complex Action Task Ends: " + DateTime.Now);
            }).ToRunNow().AndEvery(1).Months().On(5).At(3, 0);

            //先执行第一个Job、再执行第二个Job;完成后等5秒继续循环
            Schedule<MyFirstJob>().AndThen<MySecoundJob>().ToRunNow().AndEvery(5).Seconds();
        }
    }

    public class MyJob1 : IJob
    {

        void IJob.Execute()
        {
            Trace.WriteLine("循环每2秒执行一次；现在时间是：" + DateTime.Now);
            var str = "循环每2秒执行一次；现在时间是：" + DateTime.Now.ToString();
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

    public class MyOtherJob : IJob
    {

        void IJob.Execute()
        {
            Trace.WriteLine("5秒后只执行一次 ，现在时间是：" + DateTime.Now);
        }
    }

    public class MyFirstJob : IJob
    {

        void IJob.Execute()
        {
            Trace.WriteLine("执行第一个 Job ，现在时间是：" + DateTime.Now);
        }
    }
    public class MySecoundJob : IJob
    {

        void IJob.Execute()
        {
            Trace.WriteLine("执行第二个 Job ，现在时间是：" + DateTime.Now);
        }
    }

}