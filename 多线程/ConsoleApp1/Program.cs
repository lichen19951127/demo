using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    #region 主线程与后台线程
    //class Program
    //{
    //    /// <summary>
    //    /// 多线程 线程池  悲观锁  乐观锁 
    //    /// </summary>
    //    /// <param name="args"></param>
    //    static void Main(string[] args)
    //    {
    //        //方法一：使用Thread类
    //        ThreadStart threadStart = new ThreadStart(Calculate);//通过ThreadStart委托告诉子线程执行什么方法　 
    //        Thread thread = new Thread(threadStart);
    //        thread.Start();//启动新线程
    //        ThreadStart threadStart2 = new ThreadStart(Calculate2);//通过ThreadStart委托告诉子线程执行什么方法　 
    //        Thread thread2 = new Thread(threadStart2);
    //        thread2.Start();//启动新线程

    //        for (var i = 0; i < 1000000; i++)
    //        {
    //            Console.WriteLine("主线程计数" + i);
    //            //Thread.Sleep(100);
    //        }

    //    }
    //    public static void Calculate()
    //    {
    //        for (var i = 0; i < 1000000; i++)
    //        {
    //            Console.WriteLine("后台线程计数" + i);
    //            //Thread.Sleep(100);
    //        }
    //    }
    //    public static void Calculate2()
    //    {
    //        for (var i = 0; i < 1000000; i++)
    //        {
    //            Console.WriteLine("222后台线程计数" + i);
    //            //Thread.Sleep(100);
    //        }
    //    }
    //}

    #endregion
    #region 有参又有返回值的委托
    //class Program
    //{
    //    public delegate string MethodCaller(string name);//定义个代理 
    //    /// <summary>
    //    /// 有参又有返回值的委托
    //    /// </summary>
    //    /// <param name="args"></param>
    //    static void Main(string[] args)
    //    {

    //         MethodCaller mc = new MethodCaller(GetName);
    //         string name = "my name";//输入参数 
    //         IAsyncResult result = mc.BeginInvoke(name, null, null);
    //         string myname = mc.EndInvoke(result);//用于接收返回值 

    //    }
    //    public static string GetName(string name)    // 函数
    //    {
    //        return name;
    //    }
    //}
    #endregion

    #region 线程阻塞 Join Sleep 此时不占用CPU
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Thread t = new Thread(Go);
    //        t.Start();
    //        //通过调用一个线程的Join方法，可以等待另外一个线程结束
    //        //t.Join();
    //        Thread.Sleep(5000);
    //        Console.WriteLine("Thread t has ended!");
    //        Console.ReadKey();

    //    }
    //    static void Go()
    //    {
    //        for (int i = 0; i < 1000; i++)
    //        {
    //            Console.Write("y");
    //        }
    //    }
    //}
    #endregion

    #region 悲观锁 线程安全
    //关于多个线程同时使用一个对象或资源的情况，也就是线程的资源共享，为了避免数据紊乱，一般采用.Net悲观锁lock的方式处理
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        BookShop book = new BookShop();
    //        //创建两个线程同时访问Sale方法
    //        Thread t1 = new Thread(new ThreadStart(book.Sale));
    //        Thread t2 = new Thread(new ThreadStart(book.Sale));
    //        //启动线程
    //        t1.Start();
    //        t2.Start();
    //        Console.ReadKey();
    //    }
    //}
    //class BookShop
    //{
    //    //剩余图书数量
    //    public int num = 1;
    //    public void Sale()
    //    {
    //        //使用lock关键字解决线程同步问题
    //        lock (this)
    //        {
    //            int tmp = num;
    //            if (tmp > 0)//判断是否有书，如果有就可以卖
    //            {
    //                Thread.Sleep(1000);
    //                num -= 1;
    //                Console.WriteLine("售出一本图书，还剩余{0}本", num);
    //            }
    //            else
    //            {
    //                Console.WriteLine("没有了");
    //            }
    //        }
    //    }
    //}
    #endregion

    #region Task方式使用多线程：这种方式一般用在需要循环处理某项业务并且需要得到处理后的结果
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //        List<Task> lstTaskBD = new List<Task>();
    //        foreach (var bd in lstBoards)
    //        {
    //            var bdTmp = bd;//这里必须要用一个临时变量
    //            var oTask = Task.Factory.StartNew(() =>
    //            {
    //                var strCpBdCmd = "rm -Rf " + bdTmp.Path + "/*;cp -R " + CombineFTPPaths(FTP_EMULATION_BD_ROOT,

    //  "bd_correct") + "/* " + bdTmp.Path + "/";
    //                oPlink.Run(bdTmp.EmulationServer.BigIP, bdTmp.EmulationServer.UserName, bdTmp.EmulationServer.Password,strCpBdCmd);
    //                Thread.Sleep(500);
    //            });
    //            lstTaskBD.Add(oTask);
    //        }
    //        Task.WaitAll(lstTaskBD.ToArray());//等待所有线程只都行完毕

    //    }
    //}

    #endregion

    #region 线程池
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadMethod1), new object());    //参数可选
    //        Console.ReadKey();

    //    }
    //    public static void ThreadMethod1(object val)
    //    {
    //        for (int i = 0; i <= 500000000; i++)
    //        {
    //            if (i % 1000000 == 0)
    //            {
    //                Console.Write(Thread.CurrentThread.Name);
    //            }
    //        }
    //    }
    //}
    #endregion
}
