using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("老虎猫", "蓝色");           
            mouse mouse1=new mouse("米老鼠","灰色",cat);
          //  cat.CatCome += mouse1.RunAway;
            mouse mouse2 = new mouse("唐老鸭", "黑色",cat);
         //   cat.CatCome += mouse2.RunAway;
            mouse mouse3 = new mouse("任意猫", "任意色",cat);
          //  cat.CatCome += mouse3.RunAway;
           cat.CatComing();//猫的状态发生改变
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 定义一个猫类
    /// </summary>
    class Cat
    {
        public string name;
        public string color;

        public Cat(string name, string color)
        {
            this.name = name;
            this.color = color;
        }
        /// <summary>
        /// 定义猫来了状态
        /// </summary>
        public void CatComing()
        {
            Console.WriteLine(color + "这个" + name + "来了，喵喵猫~~~");
            if (CatCome != null)

                CatCome();

        }
        /// <summary>
        /// 定义一个事件
        /// </summary>
        public event Action CatCome;

    }

    /// <summary>
    /// 定义一个老鼠类
    /// </summary>
    class mouse
    {
        public string name;
        public string color;

        public mouse(string name, string color, Cat cat)
        {
            this.name = name;
            this.color = color;
            cat.CatCome += this.RunAway;//将猫自身的方法注册进老鼠中
        }

        public void RunAway()
        {
            Console.WriteLine(color + "这个" + name + "的跑了~~~");
        }
    }
}
