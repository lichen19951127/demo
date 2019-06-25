using System;

namespace MP算法
{
    //MP算法原理：模式串与主串进行匹配，进行到i处（模式串在j处）发现不匹配，如果模式串j处之前有前缀n个字符与主串i处

    //之前n个字符相匹配，则可将模式串j移动到n处，重新与i进行匹配（此时i的位置不变）即可。依次类推，直到匹配结束。
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "GCATCGCAGAGAGTATACAGTACG";
            string s2 = "GCAGAGAG";
            int m = Program.MpMatchStr(s1, s2, 1);
            Console.WriteLine("MP方法匹配的位置为:" + m);
        }
        private static int[] MpNext(string s1)   //s1为模式串
        {
            int[] next = new int[s1.Length + 1];  //数组的长度可以为s1.length，这里为s1.length+1，在多次匹配中才有意义。
            int i = 1, j = 0;
            next[0] = -1;
            next[1] = 0;
            while (i < s1.Length)
            {
                if (j == -1 || s1[i] == s1[j])        //j==-1的条件是为了避免i=0时候，next[0]=-1，造成的下标越界
                {
                    i++;
                    j++;
                    next[i] = j;
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
            int[] next = MpNext(s2);
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
