using System;

namespace KMP算法
{
    //KMP算法是由MP算法发展过来的。同样是借助一个next[]数组。但是next[]数组的n的值有一点不同。

//KMP算法原理基本上与MP相同。不同处在于：如果主串中的i处与模式串j处不匹配，且MP算法的next[j] 为n，则下一次匹配则为主串中的i处与模式串中的n处进行匹配。但是若模式串n处的值与j处的值相等，则主串中的i处必然不等于n处，所以此处next[j] 的值可以修正为一个更小的值m。

    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "GCATCGCAGAGAGTATACAGTACG";
            string s2 = "GCAGAGAG";

            int x = Program.MpMatchStr(s1, s2, 1);
            Console.WriteLine("KMP方法匹配的位置为:" + x);
        }
        private static int[] KmpNext(string s1)
        {
            int[] next = new int[s1.Length + 1];
            int i = 1, j = 0;
            next[0] = -1;
            next[1] = 0;
            while (i < s1.Length)
            {
                if (j == -1 || s1[i] == s1[j])
                {
                    i++;
                    j++;
                    if (i < s1.Length && s1[i] == s1[j])
                    {
                        next[i] = next[j];
                    }
                    else
                    {
                        next[i] = j;
                    }
                }
                else
                {
                    j = next[j];
                }
            }


            return next;
        }

        public static int MpMatchStr(string s1, string s2, int n)
        {
            int[] next = KmpNext(s2);
            int i = n - 1, j = 0;
            bool IsMatch = false;
            while (!IsMatch)
            {
                if (j == -1 || s1[i] == s2[j])
                {
                    i++;
                    j++;
                }
                else
                {

                    j = next[j];

                }
                if (j == s2.Length)
                {
                    IsMatch = true;
                    n = i - j + 1;
                }
            }

            if (IsMatch)
            {
                Console.WriteLine("MP方法匹配成功");
            }
            else
            {
                n = -1;
                Console.WriteLine("MP方法匹配失败");
            }
            return n;
        }
    }
}
