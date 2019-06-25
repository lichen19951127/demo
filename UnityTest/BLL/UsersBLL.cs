using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    using IBLL;
    using IDAL;
    public class UsersBLL : IUsers_BLL
    {
        private IUsers_DAL iUsers_DAL;
        public UsersBLL(IUsers_DAL _iUsers_DAL)
        {
            iUsers_DAL = _iUsers_DAL;
        }
        public bool GetValues()
        {
            return iUsers_DAL.GetValues() == "正在使用Unity";
        }
    }
}
