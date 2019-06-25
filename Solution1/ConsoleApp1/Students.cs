using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    #region Students类 继承基类
    //public class Students:School
    //{

    //    public Students()
    //    {

    //    }
    //    public Students(int _Id,string _Name,int _Age) 
    //    {
    //        this.Id = _Id;
    //        this.Name = _Name;
    //        this.Age = _Age;
    //    }
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int Age { get; set; }

    //    /// <summary>
    //    /// 重载
    //    /// </summary>
    //    public void Methods()
    //    {
    //        Console.WriteLine("重载1:没有参数");
    //    }
    //    public void Methods(int Id)
    //    {
    //        Console.WriteLine("重载2:参数Id:" + Id);
    //    }
    //    public void Methods(string Name)
    //    {
    //        Console.WriteLine("重载3:参数Name:" + Name);
    //    }
    //    public void Methods(int Id,string Name)
    //    {
    //        Console.WriteLine("重载4:参数Id:" + Id+"参数Name:" + Name);
    //    }
    //    public void Methods(string Name,int Id)
    //    {
    //        Console.WriteLine("重载5:参数Name:" + Name+ "参数Id:" + Id);
    //    }
    //    /// <summary>
    //    /// 重写
    //    /// </summary>
    //    public override void Test()
    //    {
    //        Console.WriteLine("我是派生类的方法");
    //    }

    //    /// <summary>
    //    /// out
    //    /// </summary>
    //    /// <param name="num">输入参数</param>
    //    /// <param name="Num1">返回参数1</param>
    //    /// <param name="Name">返回参数2</param>
    //    /// <returns>返回三个值</returns>
    //    public int GetValues(int num, out int Num1, out string Name)
    //    {
    //        num++;
    //        //out参数初始化
    //        Num1=num++;
    //        Name = "张三";
    //        return num;
    //    }
    //    /// <summary>
    //    /// ref
    //    /// </summary>
    //    /// <param name="values">输入参数</param>
    //    /// <param name="name">返回参数</param>
    //    /// <returns>返回两个值</returns>
    //    public int GetTestValues(int values, ref string name)
    //    {
    //        return values;
    //    }

    //    /// <summary>
    //    /// 可选参数与必选参数 可选参数必须放在必选参数之后
    //    /// </summary>
    //    /// <param name="id">必选参数Id</param>
    //    /// <param name="name">可选参数name</param>
    //    /// <param name="sex">可选参数sex</param>
    //    /// <returns></returns>
    //    public int GetTestValues1(int id, string name = "", int sex = 0)
    //    {
    //        return id;
    //    }
    //}
    #endregion

    #region Students类 继承接口
    public class Students : IStudent
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Add(int id, int num)
        {
            return 1;
        }
    }
    #endregion
}
