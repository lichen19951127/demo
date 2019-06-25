using System;
using System.Collections.Generic;
using System.Text;

namespace TrieTreeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("上海市");
            list.Add("上海滩");
            list.Add("上海人");
            list.Add("上海公司");
            list.Add("北京");
            list.Add("北斗星");
            list.Add("杨柳");
            list.Add("杨浦区");
            TrieTree tt = TrieFactory.Create(list);
            string text= "上海市杨浦区";
            int n=3;

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (n + i-1 <= text.Length)
                {
                    string substr = text.Substring(i, n);
                    if (tt.GetFrequency(substr) > 0)
                    {
                        result.Append(substr);
                        result.Append("|");
                        i += substr.Length-1;
                    }
                }
                    
            }
            Console.WriteLine(result.ToString());
            Console.Read();
        }
    }
}
