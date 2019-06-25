using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        /// <summary>
        /// 有参数有返回值的委托
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Thread oThread = new Thread(new ParameterizedThreadStart(Test2));
            //当在主线程中创建了一个线程，那么该线程的IsBackground默认是设置为false的。
            //当主线程退出的时候，IsBackground=FALSE的线程还会继续执行下去，直到线程执行结束。
            //只有IsBackground=TRUE的线程才会随着主线程的退出而退出。
            //当初始化一个线程，把Thread.IsBackground=true的时候，指示该线程为后台线程。后台线程将会随着主线程的退出而退出。

            oThread.IsBackground = true;
            oThread.Start(1000);

            for (var i = 0; i < 1000000; i++)
            {
                Console.WriteLine("主线程计数" + i);
                //Thread.Sleep(100);
            }

        }
        private static void Test2(object Count)
        {
            for (var i = 0; i < (int)Count; i++)
            {
                Console.WriteLine("后台线程计数" + i);
                //Thread.Sleep(100);
            }
        }
    }
}
