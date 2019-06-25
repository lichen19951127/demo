using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemo
{
    public class CSharp : IProgrammer
    {
        public void Working()
        {
            Console.WriteLine("C#");
        }
    }

    public class VB : IProgrammer
    {
        public void Working()
        {
            Console.WriteLine("VB");
        }
    }

    public class Java : IProgrammer
    {
        public void Working()
        {
            Console.WriteLine("Java");
        }
    }
}
