using System;
using System.Threading;

namespace Test01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始");
            Thread t = new Thread(Run) {
                //设为后台线程
                IsBackground = true};
            t.Start();
            Console.WriteLine("主线程在做其他的事情");
            //主线程结束 后台线程会自动结束,不管有没有执行完成
            Thread.Sleep(1500);
            Console.WriteLine("主线程结束");
        }

        private static void Run()
        {
            Thread.Sleep(700);
            Console.WriteLine("这是后台线程调用");
        }
    }
}
