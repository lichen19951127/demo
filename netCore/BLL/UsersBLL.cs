using System;

namespace BLL
{
    using Entity;
    using IDAL;
    using IBLL;
    using System.Collections.Generic;

    public class UsersBLL : IUsers_BLL
    {
        private IUsers_DAL iUsers_DAL;

        public UsersBLL(IUsers_DAL _IUsers_DAL)
        {
            iUsers_DAL= _IUsers_DAL;
        }
        public string GetValue()
        {
            var result = iUsers_DAL.GetValue();
            return result;
        }

        public List<Users> Query()
        {
            var result = iUsers_DAL.Query();
            return result;
        }
    }
}
