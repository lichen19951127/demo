using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Users u=new Users ();
            u.Id = 1;
            u.Name = "张三";


            




            Console.ReadKey();
        }
    }

    public class Users
    {
        public int Id{ get; set; }
        public string Name { get; set; }
    }
}
