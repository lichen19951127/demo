using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlite
{
    using System.Data.SQLite;
    class Program
    {
        static void Main(string[] args)
        {
            ProductService p = new ProductService();
           var dt= p.GetData();
            Console.ReadKey();

        }
    }
}
