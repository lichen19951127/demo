using System;

namespace Rabin_Karp算法
{
    class Program
    {
        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        static extern bool QueryPerformanceCounter(ref long count);
        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        static extern bool QueryPerformanceFrequency(ref long count);
        public int len = 0;
        public int[] a = new int[1000000];
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public double RK(string s, string p)//RK匹配算法
        {
            int d = 128;
            int q = 127;
            long count = 0;
            long count1 = 0;
            long freq = 0;
            double result = 0;
            QueryPerformanceFrequency(ref freq);
            QueryPerformanceCounter(ref count);
            int lenp = p.Length;//模式串长度
            int lens = s.Length;//主串长度。
            int w = 0, t = 0, h = 1, j;//w是模式串哈希值，t是主串哈希值，h是最高位的值。
            len = 0;//统计匹配成功的次数。
            for (int i = 0; i < lenp - 1; i++)
                h = (h * d) % q;//求最高位值
            for (int i = 0; i < lenp && i < lens; i++)
            {
                w = (d * w + p[i]) % q;//求模式串哈希值。
                t = (d * t + s[i]) % q;//求主串哈希值。
            }
            for (int i = 0; i <= lens - lenp; i++)
            {
                if (w == t)//判断模式串哈希值是否等于主串哈希值。
                {
                    for (j = 0; j < lenp; j++)//深入匹配，确认两串是否相等。
                        if (s[i + j] != p[j]) break;
                    if (j == lenp)//判断相同串的长度是否等于模式串的长度。
                    {
                        a[++len] = i;
                    }
                }
                if (i < lens - lenp)//模式串与主串的哈希值不相同，模式串向右移动。
                {
                    t = (d * (t - s[i] * h) + s[i + lenp]) % q;//通过减去最高位的值*进制数+下一位的哈希值来进行巧妙右移。
                    if (t < 0) t += q;
                }
            }
            QueryPerformanceCounter(ref count1);
            count = count1 - count;
            result = (double)(count) / (double)freq;
            return result;
        }


        public double KMP(string s, string p)//KMP算法
        {
            long count = 0;
            long count1 = 0;
            long freq = 0;
            double result = 0;
            QueryPerformanceFrequency(ref freq);
            QueryPerformanceCounter(ref count);
            int[] next = new int[1000000];
            int i = 0, j = 0;
            len = 0;//统计匹配成功的次数。
            int lens = s.Length;//主串长度。
            int lenp = p.Length;//模式串长度。
            int k = -1;
            next[0] = -1;//初始化next数组。
            while (i < lenp)
            {
                if (k == -1 || p[i] == p[k])//若p[i]==p[k]，则有p[0..k]==p[i-k,i]，很显然，next[i+1]=next[i]+1=k+1;
                {
                    i++;
                    k++;
                    next[i] = k;
                }
                else k = next[k];//若p[i]!=p[k]，则可以把其看做模式匹配的问题，即匹配失败的时候，k值如何移动，显然k=next[k]。
            }
            i = j = 0;
            while (i < lens)
            {
                if (j == -1 || (j >= 0 && i >= 0 && i < lens && j < lenp && s[i] == p[j])) //这一位相同，就往后一位匹配。
                {
                    i++;
                    j++;
                }
                else j = next[j];//匹配不上，从next数组中取出模式串
                if (j == lenp)//判断匹配上的长度是否等于模式串长度。
                {
                    a[++len] = i - lenp;
                }
            }
            QueryPerformanceCounter(ref count1);
            count = count1 - count;
            result = (double)(count) / (double)freq;
            return result;
        }
    }
}
