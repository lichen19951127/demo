using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    using Entity;
    public interface IUsers_BLL
    {
        bool Add(Users u);
        Users QueryById(int id);
    }
}
