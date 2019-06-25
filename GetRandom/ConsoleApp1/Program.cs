using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseRandom br = new BaseRandom();
            Console.WriteLine("Hello World!");

            Console.WriteLine(br.GetRandom());

            Console.WriteLine(GetTimeStamp());
            Console.WriteLine(GenerateIntID());
            Console.WriteLine(GenerateIntID());
            Console.WriteLine(GenerateIntID());
            Console.WriteLine(GenerateIntID());
            Console.ReadKey();
        }
        /// <summary> 
        /// 获取时间戳 
        /// </summary> 
        /// <returns></returns> 
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 如果你想生成一个数字序列而不是字符串，你将会获得一个19位长的序列。下面的方法会把GUID转换为Int64的数字序列。
        /// </summary>
        /// <returns></returns>
        public static long GenerateIntID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
