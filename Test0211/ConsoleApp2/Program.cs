using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "abc";
            String aa = "abc";
            StringBuilder aaa = new StringBuilder();
            aaa.Append("123");
            aaa.Append("456");
            aaa.Append("789");
           
          var aaaa=  aaa.Length;
            Console.ReadKey();
        }
    }
}
