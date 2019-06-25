using System;

namespace DotNetCore.IService
{
    public interface IBase<T> where T:class,new()
    {
        bool Add(T t);
        bool Delete(string Id);
        bool Update(T t);
        T QueryById(int Id);
    }
}
