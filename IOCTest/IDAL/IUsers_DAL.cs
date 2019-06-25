using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    using Entity;
    public interface IUsers_DAL
    {
        int Add(Users u);
        int Delete(string ids);
        int Update(Users u);
        List<Users> Query();
    }
}
