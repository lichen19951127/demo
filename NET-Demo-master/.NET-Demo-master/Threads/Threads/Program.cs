using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            // synchronous method call
            // TakesAWhile(1,3000);

            // asynchronous by using a delegate
            TakesAWhileDelegate dl = TakesAWhile;
            dl.BeginInvoke(1, 500, TakesAWhileCompleted, dl);
            for (int i = 0; i < 100; i++)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }

            /**
            IAsyncResult ar = dl.BeginInvoke(1, 500, null, null);
            /**
             * 投票
            while (!ar.IsCompleted)
            {
                // doing something else in the main thread
                Console.Write(".");
                Thread.Sleep(50);
            }*/

            /**
             * 等待句柄
            while (true)
            {
                Console.Write(".");
                if (ar.AsyncWaitHandle.WaitOne(50, false))
                {
                    Console.WriteLine("Can get the result now");
                    break;
                }
            }*/

            /**
             * 投票/等待句柄
            int result = dl.EndInvoke(ar);
            Console.WriteLine("result:{0}", result);*/

            /**
             * Thread 创建线程
            var t1 = new Thread(ThreadMain) { Name = "MyNewThread", IsBackground = false };
            t1.Start();
            Console.WriteLine("Main thread ending now.");
            */

            /**
             * ThreadPool 线程池创建
            int nWorkerThreads;
            int nCompletionPortThreads;
            ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionPortThreads);
            Console.WriteLine("Max worker threads:{0},I/O completion threads:{1}",
                nWorkerThreads, nCompletionPortThreads);
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(JobForAThread);
            }
            */

            //using task factory
            TaskFactory tf = new TaskFactory();
            Task t1 = tf.StartNew(TaskMethod);

            //using the task factory via a task
            Task t2 = Task.Factory.StartNew(TaskMethod);

            //using Task constructor
            Task t3 = new Task(TaskMethod);
            t3.Start();

            Task t4 = new Task(TaskMethod, TaskCreationOptions.PreferFairness);
            t4.Start();

            Console.ReadLine();
        }

        #region 任务方法
        /// <summary>
        /// 任务方法
        /// </summary>
        static void TaskMethod()
        {
            Console.WriteLine("running in a task");
            Console.WriteLine("Task id:{0}", Task.CurrentId);
        }
        #endregion

        #region 线程池方法
        /// <summary>
        /// 线程池方法
        /// </summary>
        /// <param name="state"></param>
        static void JobForAThread(object state)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("loop{0},running inside pooled thread{1}",
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(50);
            }
        }
        #endregion

        #region 异步回调方法
        /// <summary>
        /// 异步回调方法
        /// </summary>
        /// <param name="ar"></param>
        static void TakesAWhileCompleted(IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");
            TakesAWhileDelegate dl = ar.AsyncState as TakesAWhileDelegate;
            Trace.Assert(dl != null, "Invalid object type");

            int result = dl.EndInvoke(ar);
            Console.WriteLine("result:{0}", result);
        }
        #endregion

        #region 委托方法
        public delegate int TakesAWhileDelegate(int data, int ms);

        static int TakesAWhile(int data, int ms)
        {
            Console.WriteLine("TakesAWhile started");
            Thread.Sleep(ms);
            Console.WriteLine("TakesAWhile completed");
            return ++data;
        }
        #endregion

        #region 线程方法
        /// <summary>
        /// 线程方法
        /// </summary>
        static void ThreadMain()
        {
            Console.WriteLine("Thread {0} started", Thread.CurrentThread.Name);
            Thread.Sleep(3000);
            Console.WriteLine("Thread {0} completed", Thread.CurrentThread.Name);
        }
        #endregion

    }
}
