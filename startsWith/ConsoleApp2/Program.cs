using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Info> list = new List<Info>();
            Info info1 = new Info() { Name= "abc123456" };
            list.Add(info1);
            Info info2 = new Info() { Name = "ab123456" };
            list.Add(info2);
            Info info3 = new Info() { Name = "abcd123456" };
            list.Add(info3);
            //取出 info2  不为abc开头的数据
            var aaa = list.Where(m => !m.Name.StartsWith("abc")).ToList();
            var aaa1 = list.Where(m => m.Name.StartsWith("abc")==false).ToList();
        }
    }
    public class Info
    {
        public string Name { get; set; }
    }
}
