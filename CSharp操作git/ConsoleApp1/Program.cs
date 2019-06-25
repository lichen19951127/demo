using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("walterlv 的自动 git 命令");

            var git = new CommandRunner("git", @"D:\Git\git-bash.exe");
            var status = git.Run("status");

            Console.WriteLine(status);
            Console.WriteLine("按 Enter 退出程序……");
            Console.ReadLine();
        }
    }
}
