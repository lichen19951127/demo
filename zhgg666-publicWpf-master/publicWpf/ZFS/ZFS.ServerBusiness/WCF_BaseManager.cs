using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.ServerBusiness
{
    public class WCF_BaseManager<T> where T : class, new()
    {
        public static T _Manager;

        public static ServiceReference.BaseServiceClient Server;
        public static T GetManager()
        {
            if (_Manager == null)
            {
                _Manager = new T();
                Server = new ServiceReference.BaseServiceClient();
            }
            return _Manager;
        }
    }
}
