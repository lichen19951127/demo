using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var oldCon = "server=123.56.219.247;database=its;uid=sa;pwd=Lc19951127.;";
            var sql = "select * from MallGoods";
            var dt = GetDT(oldCon,sql);

            var newCon = "server=127.0.0.1;database=its;uid=sa;pwd=1;";
            SqlBulkCopyInsert(newCon, "MallGoods", dt);
        }
        public static DataTable GetDT(string conn, string sql)
        {
        
            using (var con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(sql,con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }
        #region 使用SqlBulkCopy将DataTable中的数据批量插入数据库中
        /// <summary>  
        /// 注意：DataTable中的列需要与数据库表中的列完全一致。/// </summary>  
        /// <param name="conStr">数据库连接串</param>
        /// <param name="strTableName">数据库中对应的表名</param>  
        /// <param name="dtData">数据集</param>  
        public static void SqlBulkCopyInsert(string conStr, string strTableName, DataTable dtData)
        {
            try
            {
                using (SqlBulkCopy sqlRevdBulkCopy = new SqlBulkCopy(conStr))           //引用SqlBulkCopy  
                {
                    sqlRevdBulkCopy.DestinationTableName = strTableName;                //数据库中对应的表名  
                    sqlRevdBulkCopy.NotifyAfter = dtData.Rows.Count;                    //有几行数据  
                    sqlRevdBulkCopy.WriteToServer(dtData);                              //数据导入数据库  
                    sqlRevdBulkCopy.Close();                                            //关闭连接  
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}
