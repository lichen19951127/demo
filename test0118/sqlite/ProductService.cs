using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlite
{
    public class ProductService
    {
        public static readonly ProductService Instance = new ProductService();
        private static string connstr = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;

        public DataTable GetData()
        {
            SQLiteConnection conn = null;
            int num = 0;
            int productNum = 10;
            try
            {
                conn = new SQLiteConnection(connstr);
                conn.Open();
                string sql = "select * from users";
                //SQLiteParameter[] parameter = { new SQLiteParameter("@product", product), new SQLiteParameter("@productNum", productNum) };
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                //cmd.Parameters.AddRange(parameter);
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
       
        }
    }
}
