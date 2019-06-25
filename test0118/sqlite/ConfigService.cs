using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlite
{
    public class ConfigService
    {
        public static string ConnectionString
        {
            get
            {
                return "Data Source=" + AppDomain.CurrentDomain.BaseDirectory +ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;

            }
        }

    }
}
