using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using FluentScheduler;
    class Program
    {
        static void Main(string[] args)
        {
            //两个参数分别：Job、调度时间
            JobManager.AddJob(() =>
            {
                //任务逻辑
                Console.WriteLine("Timer task,current time:{0}", DateTime.Now);
            }, t =>
            {
                //时间

                //从程序启动开始执行，然后每秒钟执行一次
                t.ToRunNow().AndEvery(1).Seconds();
                ////带有任务名称的任务定时器
                //t.WithName("TimerTask").ToRunOnceAt(DateTime.Now.AddSeconds(5));
            });


            Console.ReadKey();
        }
    }
}
