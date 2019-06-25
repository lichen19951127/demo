using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Service
{
    public interface IService<T> where T:class,new()
    {
        int Add(T t);
        int Update(T t);
        List<T> Query();
        T QueryById(string Id);
    }
}
