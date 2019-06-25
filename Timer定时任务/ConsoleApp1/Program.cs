using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTimer timer = new MyTimer();
            timer.Interval=1000;
            timer.Start();
            timer.date = Convert.ToDateTime("2019-04-30 11:59");
            timer.Elapsed += new System.Timers.ElapsedEventHandler(test);

            Console.ReadKey();
        }

        private static void test(object sender, ElapsedEventArgs e)
        {
            MyTimer timer = (MyTimer)sender;
            DateTime date = timer.date;
            if (DateTime.Now.ToString("yy-MM-dd hh:ss") == date.ToString("yy-MM-dd hh:ss"))
            {
                Console.WriteLine("北京时间"+DateTime.Now);
            }
        }
    }

    public class MyTimer : System.Timers.Timer
    {
        public DateTime date { get; set; }
    }
}
