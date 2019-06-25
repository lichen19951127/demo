//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using static System.Console;
//using CC = System.ConsoleColor;

//namespace ConsoleApp1
//{
   
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine(nameof(CC));//CC
//            Console.WriteLine(nameof(CC.Red));//Red
//            Console.WriteLine(nameof(System.ConsoleColor));//ConsoleColor
//            Console.WriteLine(typeof(System.ConsoleColor).FullName);//System.ConsoleColor
//            Console.ReadKey();
//        }
//    }
//}

using System;

namespace ConsoleApp1
{
    /// <summary>
    ///     C# nameof用法
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            Console.Title = "C# nameof用法";

            Person p = new Person();
            Console.WriteLine(nameof(p));//p
            Console.WriteLine(nameof(p.Name));//Name
            Console.WriteLine(nameof(Person.CreateDateTime));//CreateDateTime

            Console.ReadKey();
        }
    }

    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
