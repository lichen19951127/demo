using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var key = DESHelper.MD5Encrypt("636774425125887447", DESHelper.GetKey());
         Console.WriteLine(key);


            Console.WriteLine(DESHelper.MD5Decrypt(key, DESHelper.GetKey()));

            Console.ReadKey();

        }
    }
}
