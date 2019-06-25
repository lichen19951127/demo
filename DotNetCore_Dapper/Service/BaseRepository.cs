
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Service
{
    public class BaseRepository : IDisposable
    {
        public static IConfigurationRoot Configuration { get; set; }

        private MySqlConnection conn;
        public static string DB_ConnectionString { get; set; }
        public MySqlConnection GetMySqlConnection()
        {
            conn = new MySqlConnection(DB_ConnectionString);
            return conn;
        }
        public void Dispose()
        {
            if (conn != null && conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }
}
