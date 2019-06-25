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
            #region
            //Students stu = new Students(1,"张三",20);
            ////重写
            //stu.Test();
            ////重载
            //stu.Methods();
            //stu.Methods(1);
            //stu.Methods("张三");
            //stu.Methods(1,"张三");
            //stu.Methods("张三",1);

            ////一个方法返回多个值时可以用 out或ref
            //int num;
            //string name;
            ////out方法内需要初始化
            //stu.GetValues(1,out num,out name);
            //Console.WriteLine("out两个参数值为:"+num+name);
            ////ref方法体内无需初始化,但接受返回参数必须初始化
            //string reName = "李四";
            //stu.GetTestValues(1,ref reName);
            //Console.WriteLine("ref一个参数值为:" + reName);

            ////可选参数与必选参数
            //stu.GetTestValues1(0);
            //stu.GetTestValues1(0,"admin");
            //stu.GetTestValues1(0,"admin",0);
            #endregion

            //接口的对象就是实现了接口类的对象
            IEmployee<Employee> emp = new Employee_DAL();
            Console.WriteLine(emp.Add(new Employee()));

            Console.ReadKey();
        }
    }
}
