using System;

namespace WeChatAppletServer.IService
{
    public interface IBaseService<T> where T:class,new()
    {
        bool Add(T t);
        bool Update(T t);
        bool Delete(int Id);
        T GetSingle(int Id);
    }
}
