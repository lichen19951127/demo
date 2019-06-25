using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public class School
    {

        public string Classes { get; set; }
        public virtual void Test()
        {
            Console.WriteLine("我是基类的方法");
        }
    }
}
