using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //阶乘n!= 1*2*3*4*5*...*n
            //1=1
            //2=1*2  
            //3=1*2*3
            //4=1*2*3*4
            //5=1*2*3*4*5
            //6=1*2*3*4*5*6  

            Console.WriteLine(Factory(0));
            Console.WriteLine(Factory(1));
            Console.WriteLine(Factory(2));
            Console.WriteLine(Factory(3));
            Console.WriteLine(Factory(4));
            Console.WriteLine(Factory(5));
            Console.WriteLine(Factory(6));
            Console.WriteLine(Factory(7));
            Console.WriteLine(Factory(8));
            Console.WriteLine(Factory(9));
            Console.WriteLine(Factory(10));
        }
        public static int Factory(int n)
        {
            //0   1
            //1*(1-1)
            //2*(1*(1-1))
            int sum = 0;
            if (n == 0)
            {
                return 1;
            }
            else
            {
                sum = n * Factory(n-1);
            }
            return sum;
        }
    }
}
