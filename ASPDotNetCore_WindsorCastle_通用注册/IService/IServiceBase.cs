using System;

namespace IService
{
    public interface IServiceBase<T> where T : class, new()
    {
        string GetValue();

    }
}
