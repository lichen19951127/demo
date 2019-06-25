using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //怪物类
            Monster monster = new Monster(1000);
            //物理攻击类
            Play play1 = new Play() { Name = "无敌剑圣", Power = 100 };
            //魔法攻击类
            Play play2 = new Play() { Name = "流浪法师", Power = 120 };
            Thread thread_first = new Thread(play1.physicsExecute);    //物理攻击线程
            Thread thread_second = new Thread(play2.magicExecute);     //魔法攻击线程
            thread_first.Start(monster);
            thread_second.Start(monster);
            Console.ReadKey();
        }
    }
}
