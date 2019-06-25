using BLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*Program 开始运行 : " + DateTime.Now);
            var business = new Business();

            var swRead = new Stopwatch();
            //swRead.Start();
            //business.AddToDb();//sqlserver数据库增加数据
            //swRead.Stop();
            //Console.WriteLine("DB 写入时间  : " + swRead.ElapsedMilliseconds);

            //swRead.Reset();
            //swRead.Start();
            //business.AddToElasticIndex();
            //swRead.Stop();
            //Console.WriteLine("ES 写入时间  : " + swRead.ElapsedMilliseconds);

            var sw = new Stopwatch();
            sw.Start();
            var personsFromDB = business.GetFromDB();
            sw.Stop();
            Console.WriteLine("DB 读时间  : " + sw.ElapsedMilliseconds);

            sw.Reset();
            sw.Start();
            var personsFromEs = business.GetFromES();
            sw.Stop();
            Console.WriteLine("ES 读时间  : " + sw.ElapsedMilliseconds);

            Console.ReadLine();
        }
    }
}
