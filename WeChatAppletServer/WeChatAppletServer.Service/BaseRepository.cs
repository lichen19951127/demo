using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace WeChatAppletServer.Service
{
    public class BaseRepository : IDisposable
    {
        private SqlConnection conn;
        public static string DB_ConnectionString = AppConfigurtaionServices.Configuration["MyConnStr:SqlServer"];
        public SqlConnection GetSqlConnection()
        {
            conn = new SqlConnection(DB_ConnectionString);
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
