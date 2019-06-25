using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

    public class DBHelper
    {
        // 连接对象
        private static SqlConnection cnn = null;
        public static SqlConnection Cnn
        {
            get
            {
                if (cnn == null)
                {
                    //string cnnstr = "Data Source=DELL-PC\\SQLEXPRESS;Initial Catalog=zhuce;Integrated Security=True";
                    string cnnstr = "Data Source=.;Initial Catalog=test;Integrated Security=True";
                    cnn = new SqlConnection(cnnstr);
                    cnn.Open();
                }

                return cnn;
            }
        }

        public static int ExecuteScalar(string sql)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand(sql, Cnn);
            try
            {
                if (Cnn.State != ConnectionState.Open)
                {
                    Cnn.Open();
                }
                i = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Cnn.Close();
            }
            return i;
        }

        public static DataTable GetDataTable(string sql)
        {
            //cnn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, Cnn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sda.Dispose();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
            return dt;
        }
       
       
        public static int ExecuteNonQuery(string sql)
        {
            Cnn.Close();
            Cnn.Open();
            SqlCommand cmm = new SqlCommand(sql, Cnn);
            return cmm.ExecuteNonQuery();
        }
   
    }

