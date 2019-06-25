using System.Data.SqlClient;
using System.Net.Configuration;

namespace WebApplication1
{
    public class DapperHelper
    {
        private static DapperHelper _dapperHelper = null;

        private readonly string _cnnstr = "";

        private DapperHelper()
        {
            _cnnstr = "Data Source=127.0.0.1;Initial Catalog=test;User ID=sa;Password=1;";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DapperHelper Instance()
        {
            if (_dapperHelper == null)
            {
                _dapperHelper = new DapperHelper();
            }
            return _dapperHelper;
        }

        public SqlConnection GetConnection()
        {
            var conn = new SqlConnection(_cnnstr);
            conn.Open();
            return conn;
        }
    }
}
