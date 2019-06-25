using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class MySql
    {
        public static string constr = "database=test;Password=root;user ID=root;server=127.0.0.1";
        public static MySqlConnection conn = new MySqlConnection(constr);
    }
}
