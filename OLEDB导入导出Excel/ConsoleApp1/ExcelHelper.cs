using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class ExcelHelper
    {

        #region 导入

        /// <summary>
        /// 导入EXCEL（默认的sheet）
        /// </summary>
        /// <param name="fileName">excel文件路径</param>
        /// <returns></returns>
        public static System.Data.DataTable ImpExcelDt(string fileName)
        {
            return ImpExcelDt(fileName, "Sheet1");
        }


        /// <summary>
        /// excel 导入
        /// </summary>
        /// <param name="fileName">excel文件路径</param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static System.Data.DataTable ImpExcelDt(string fileName, string sheetName)
        {
            try
            {
               if (!File.Exists(fileName))
                {
                    return null;
                }

    // 连接字符串：Provider = Microsoft.Jet.OLEDB.4.0; Data Source = d:\test.xls; Extended Properties = 'Excel 8.0;HDR=Yes;IMEX=1;'
    //provider：表示提供程序名称
    //Data Source：这里填写Excel文件的路径
    //Extended Properties：设置Excel的特殊属性
    //Extended Properties 取值：
    //Excel 8.0 针对Excel2000及以上版本，Excel5.0 针对Excel97。
    //HDR = Yes 表示第一行包含列名,在计算行数时就不包含第一行
    //  IMEX 0:导入模式,1:导出模式: 2混合模式

                string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                OleDbConnection myConn = new OleDbConnection(strCon);
                string strCom = " SELECT * FROM [" + sheetName + "$] ";
                myConn.Open();
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
                DataSet myDataSet = new DataSet();
                myCommand.Fill(myDataSet, "[" + sheetName + "$]");
                myConn.Close();
              System.Data.DataTable dt = myDataSet.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 导出到EXCEL

        /// <summary>
        /// 将数据导出到指定的Excel文件中
        /// </summary>
        /// <param name="listView">System.Windows.Forms.ListView,指定要导出的数据源</param>
        /// <param name="destFileName">指定目标文件路径</param>
        /// <param name="tableName">要导出到的表名称</param>
        /// <param name="overWrite">指定是否覆盖已存在的表</param>
        /// <returns>导出的记录的行数</returns>
        public static int ExportToExcel(System.Data.DataTable dt, string destFileName, string tableName)
        {
            if (File.Exists(destFileName))
            {
                File.Delete(destFileName);
            }

            //得到字段名
            string szFields = "";
            string szValues = "";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                szFields += "[" + dt.Columns[i] + "],";
            }
            szFields = szFields.TrimEnd(',');
            //定义数据连接
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = GetConnectionString(destFileName);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            //打开数据库连接
            try
            {
                connection.Open();
            }
            catch
            {
                throw new Exception("目标文件路径错误。");
            }

            //创建数据库表
            try
            {
                command.CommandText = GetCreateTableSql("[" + tableName + "]", szFields.Split(','));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //如果允许覆盖则删除已有数据
                throw ex;
            }
            try
            {
               //循环处理数据------------------------------------------
                int recordCount = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    szValues = "";
                   for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        szValues += "'" + dt.Rows[i][j] + "',";
                    }
                    szValues = szValues.TrimEnd(',');
                    //组合成SQL语句并执行
                    string szSql = "INSERT INTO [" + tableName + "](" + szFields + ") VALUES(" + szValues + ")";
                    command.CommandText = szSql;
                   recordCount += command.ExecuteNonQuery();
                }
                connection.Close();
                return recordCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //得到连接字符串
        private static String GetConnectionString(string fullPath)
        {
            string szConnection;
            szConnection = "Provider=Microsoft.JET.OLEDB.4.0;Extended Properties=Excel 8.0;data source=" + fullPath;
            return szConnection;
        }

        //得到创建表的SQL语句
        private static string GetCreateTableSql(string tableName, string[] fields)
        {
            string szSql = "CREATE TABLE " + tableName + "(";
            for (int i = 0; i < fields.Length; i++)
            {
                szSql += fields[i] + " VARCHAR(200),";
            }
            szSql = szSql.TrimEnd(',') + ")";
            return szSql;
        }
        #endregion

    }
}
