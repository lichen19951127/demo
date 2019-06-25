using System;

namespace BM算法
{
//    BM算法与KMP算法的很大区别在于，KMP算法是从左往后开始匹配，而BM算法则是从右往左进行匹配。
//BM算法原理：利用坏字符数组和好后缀数组进行匹配。那么什么叫坏字符数组和好后缀数组呢。假设主串的n+s2.length与模式串的s2.length开始匹配。若匹配到主串的i处（模式串的j处）失败，此处主串i处字符便称为坏字符，则会有两种情况。
//第一种情况：坏字符从未在模式串中出现，那么直接将模式串的开始位置对准i+1处，重新进行匹配。即主串的i+s2.length处与模式串的s2.length开始匹配。
//第二种情况：坏字符在模式串的j处之前的m处出现，则可将模式串的m处与主串的i处对齐，重新进行匹配，即主串的i+s2.length-m-1处与模式串的s2.length开始匹配。

    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "GCATCGCAGAGAGTATACAGTACG";
            string s2 = "GCAGAGAG";
            int y = Program.BmMatchStr(s1, s2, 1);
            Console.WriteLine("BM方法匹配的位置为:" + y);
        }
        private static int[] BmbmBc(string s1)
        {
            int[] bmBc = new int[256];              //这里为ASCII码中的256个字符，因为不能预知模式串中的字符
            for (int i = 0; i < bmBc.Length; i++)
            {
                bmBc[i] = s1.Length;                //首先把所有值赋值为模式串的长度。
            }
            for (int i = 0; i < s1.Length - 1; i++)
            {
                bmBc[s1[i]] = s1.Length - i - 1;     //依次计算模式串中字符的bmBc值。
            }
            return bmBc;
        }
        private static int[] BmbmGs(string s1)
        {
            int[] bmGs = new int[s1.Length];



            for (int i = s1.Length - 1; i > 0; i--)
            {
                for (int s = i - 1; s >= 0; s--)      //对于第一种情况，s代表出现好后缀的位置
                {


                    if (s1[s] != s1[i])             //s1[i]处与主串是不匹配的，所以要找与s1[i]不同的值
                    {
                        if (i == s1.Length - 1)      //此时是末尾第一个字符就不匹配
                        {
                            bmGs[i] = i - s;
                        }
                        for (int k = i + 1; k < s1.Length; k++)
                        {
                            if (s1[k - i + s] != s1[k]) break;  //好后缀匹配失败，跳出
                            else
                            {
                                if (k == (s1.Length - 1))       //好后缀匹配成功
                                {
                                    bmGs[i] = i - s;
                                }
                            }
                        }
                    }
                    if (bmGs[i] > 0) break;                 //表示已经取得了一个好后缀的最小移动位置，就不用继续循环了
                }


                if (bmGs[i] == 0)                           //对应于第二种情况。第二种情况是第一种情况失败后开始的
                {
                    for (int k = Math.Min(s1.Length - 1 - i, i); k > 0; k--)  //k代表好后缀长度,好后缀一定比 s1.Length-1-i、i都小
                    {
                        int x = s1.Length - 1, y = k - 1;       //x，表示模式串尾部。
                        while (s1[x] == s1[y])
                        {
                            if (y == 0)                         //好后缀匹配成功
                            {
                                bmGs[i] = s1.Length - k;
                                break;
                            }
                            x--;
                            y--;
                        }


                    }
                    if (bmGs[i] == 0)                           //代表第三种情况。一二种情况都没出现。
                    {
                        bmGs[i] = s1.Length;
                    }
                }
            }
            return bmGs;
        }
        public static int BmMatchStr(string s1, string s2, int n)
        {
            int[] bmBc = BmbmBc(s2);
            int[] bmGs = BmbmGs(s2);
            int x = n + s2.Length - 2;
            int y = s2.Length - 1;
            bool IsMatch = false;
            while (!IsMatch)
            {
                if (s1[x] == s2[y])
                {
                    if (y == 0)
                    {
                        IsMatch = true;
                        n = x + 1;
                    }
                    x--;
                    y--;
                }
                else
                {
                    int offset = Math.Max(bmBc[s1[x]], bmGs[y]);        //偏移的最大值
                    x += offset;
                    y = s2.Length - 1;
                }

            }
            if (IsMatch)
            {
                Console.WriteLine("BM方法匹配成功");
            }
            else
            {
                n = -1;
                Console.WriteLine("BM方法匹配失败");
            }

            return n;
        }

    }
}
