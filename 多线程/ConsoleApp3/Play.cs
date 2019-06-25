using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    /// <summary>
    /// 玩家类
    /// </summary>
    internal class Play
    {
        /// <summary>
        /// 攻击者名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 攻击力
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// 法术攻击
        /// </summary>
        public void magicExecute(object monster)
        {
            Monster m = monster as Monster;
            Monitor.Enter(monster);
            while (m.Blood > 0)
            {
                Monitor.Wait(monster);
                Console.WriteLine("当前英雄:{0},正在使用法术攻击打击怪物", this.Name);
                if (m.Blood >= Power)
                {
                    m.Blood -= Power;
                }
                else
                {
                    m.Blood = 0;
                }
                Thread.Sleep(300);
                Console.WriteLine("怪物的血量还剩下{0}", m.Blood);
                Monitor.PulseAll(monster);
            }
            Monitor.Exit(monster);
        }
        /// <summary>
        /// 物理攻击
        /// </summary>
        /// <param name="monster"></param>
        public void physicsExecute(object monster)
        {
            Monster m = monster as Monster;
            Monitor.Enter(monster);
            while (m.Blood > 0)
            {
                Monitor.PulseAll(monster);
                if (Monitor.Wait(monster, 1000))     //非常关键的一句代码
                {
                    Console.WriteLine("当前英雄:{0},正在使用物理攻击打击怪物", this.Name);
                    if (m.Blood >= Power)
                    {
                        m.Blood -= Power;
                    }
                    else
                    {
                        m.Blood = 0;
                    }
                    Thread.Sleep(300);
                    Console.WriteLine("怪物的血量还剩下{0}", m.Blood);
                }
            }
            Monitor.Exit(monster);
        }
    }
}
