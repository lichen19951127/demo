using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFSData.Manager;

namespace ZFS.ServerLibrary
{
    public partial class BaseService : IBaseService
    {
        public BaseService()
        {
            if (_factory == null)
                _factory = new FactoryManager();
        }

        private FactoryManager _factory;

        public FactoryManager Factory { get { return _factory; } }

    }
}
