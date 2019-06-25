using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(c=> {
                c.SetServiceName("LogServices");
                c.SetDisplayName("LogServices");
                c.SetDescription("LogServices");

                c.Service<TopshelfService>(s=> {
                    s.ConstructUsing(b => new TopshelfService());
                    s.WhenStarted(o=>o.Start());
                    s.WhenStopped(o => o.Stop());
                });
            });
        }
    }
    public class TopshelfService
    {
        public void Start()
        {
            //服务逻辑
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += aaa;
            timer.Start();

            Console.WriteLine("开始了"+DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
         
        }

        public void aaa(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        }
        public void Stop()
        {
            Console.WriteLine("停止服务" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        }
    }
}
