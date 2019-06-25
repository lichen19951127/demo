using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// 抽象类不能被new 可以有普通成员也可以有抽象成员
    /// 普通类可以被new 不能有抽象成员
    /// </summary>
   public abstract class AbstractClass
    {
        public abstract void Add();
        public abstract int Update();
        public abstract string name { get; set; }

        public int id;

        public int ID { get; set; }

        public void AddStudents()
        {

        }
        public int UpdateStudents()
        {
            return 1;
        }
    }
    public interface ICar
    {
        void Add();
        int Update();
    }

    /// <summary>
    /// 类只能继承一个基类,接口可以继承多个
    /// 抽象类是重写  接口是实现
    /// </summary>
    public class Car:AbstractClass,ICar,IStudent
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Add()
        {
            //真的没有办法实现并给程序一个异常信息 比如鸵鸟继承吃 下蛋 飞三个方法 不需要实现飞的方法
            throw new NotImplementedException();
        }

        public int Add(int id, int num)
        {
            throw new NotImplementedException();
        }

        public override int Update()
        {
            throw new NotImplementedException();
        }
    }


}
