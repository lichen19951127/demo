using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    /// <summary>
    /// 怪物类
    /// </summary>
    internal class Monster
    {
        public int Blood { get; set; }
        public Monster(int blood)
        {
            this.Blood = blood;
            Console.WriteLine("我是怪物,我有{0}滴血", blood);
        }
    }
}
