using System;
using System.Collections;
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
            //Dictionary<string, string> dir = new Dictionary<string, string>();
            //dir.Add("1","2");
            //dir.Add("2", "2");
            //dir.Add("3", "2");
            //dir.Add("1", "1");

            //string info = "";
            //dir.TryGetValue("1", out info);

            Hashtable dir = new Hashtable();
            dir.Add("1", "2");
            dir.Add("2", "2");
            dir.Add("3", "2");
            dir.Add("1", "1");


        }
    }
}
