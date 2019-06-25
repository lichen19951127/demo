using System;

namespace BF算法
{
    class Program
    {
        // BF算法实现原理是：从主串和模式串的首位置开始，依次比较主串和模式串的各个位置，如果匹配错误，主串就返回第二个位置，模式串返回首位置，重新匹配。以此类推，直到模式串匹配成功，返回匹配成功的位置。如果没有发生匹配就返回-1。
        static void Main(string[] args)
        {
            string s1 = "GCATCGCAGAGAGTATACAGTACG";
            string s2 = "GCAGAGAG";

            int n = Program.MatchStr(s1, s2, 1);
            Console.WriteLine("普通方法匹配的位置为:" + n);

        }

        public static int MatchStr(string s1, string s2, int n)
        {
            int i = n - 1, j = 0;             //n为匹配的起始位置
            bool IsMatch = false;
            while (!IsMatch)
            {
                if (s1[i] == s2[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    i = i - j + 1;
                    j = 0;
                }
                //如果模式串匹配成功，j++,就会得到模式串长度的值。
                if (j == s2.Length)
                {
                    IsMatch = true;
                    n = i - j + 1;
                }
            }


            if (IsMatch)
            {
                Console.WriteLine("普通方法匹配成功");
            }
            else
            {
                n = -1;
                Console.WriteLine("普通方法匹配失败");
            }
            return n;
        }
    }
}
