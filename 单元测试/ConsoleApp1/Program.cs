using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("123");
        }

        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public static string GetValue(string a, string b)
        {
            return a+b;
        }
        public static bool IsBool()
        {
            return true;
        }
    }
}
