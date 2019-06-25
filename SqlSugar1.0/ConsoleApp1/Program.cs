using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using DAL;
    using Entity;

    class Program
    {
        static void Main(string[] args)
        {
            var a = new UsersDAL().Query();
            Users u = new Users();
            u.Id = 1002;
            u.Name = "张贵谦";
            var jk= new UsersDAL().AddProc(u);
            //var jk= new UsersDAL().Add(u);
            //var jk= new UsersDAL().Delete(1003);
            //var jk = new UsersDAL().Update(u);
            var i = new UsersDAL().Query();

        }
    }
}
