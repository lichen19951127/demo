using System;

namespace IService
{
    public interface IBaseService<T> where T:class,new()
    {
        int Add(T t);
        int Delete(int id);
        int Update(T t);
        T QueryById(int id);
    }
}
