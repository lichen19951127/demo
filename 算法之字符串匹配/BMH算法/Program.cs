using System;

namespace BMH算法
{
    //BMH算法算是BM算法的一个简化。BMH仅仅是依靠坏字符数组进行模式串的移动。略微不同的是，无论在何处匹配失败，
//都会依照主串中已经完成匹配的子串最右端的字符作为坏字符进行移动。坏字符数组代码同BM算法。BMH算法匹配字符串略。
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
