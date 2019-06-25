using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    using Entity;
    using IBLL;
    using IDAL;
    public class UsersBLL : IUsers_BLL
    {
        private IUsers_DAL iUsers;
        public UsersBLL(IUsers_DAL _iUsers)
        {
            iUsers = _iUsers;
        }

        public bool Add(Users u)
        {
            return iUsers.Add(u)>0;
        }

        public Users QueryById(int id)
        {
            return iUsers.Query().FirstOrDefault(m=>m.Id.Equals(id));
        }
    }
}
