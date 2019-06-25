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
        string GetValues();
        int Add(Users u);
        int Delete(string Ids);
        int Update(Users u);
        List<Users> Query();
        Users QueryById(int Id);
    }
}
