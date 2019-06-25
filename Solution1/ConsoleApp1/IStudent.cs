using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IStudent
    {
        /// <summary>
        /// 抽象方法(省略关键字)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        int Add(int id,int num);

        /// <summary>
        /// 属性
        /// </summary>
        int Id { get; set; }



    }
}
