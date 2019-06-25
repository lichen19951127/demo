using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public interface IEmployee<T> where T:class,new()
    {
        int Add(T t);
        int Delete(string ids);
        List<T> Query();
        int Update(T t);
    }
}
