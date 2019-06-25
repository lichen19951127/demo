using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Excel=Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace excel转csv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 将Csv文件转换为XLS文件
        /// </summary>
        /// <param name="FilePath">文件全路路径</param>
        /// <returns>返回转换后的Xls文件名</returns>
        public static string CSVSaveasXLS(string FilePath)
        {
            QuertExcel();
            string _NewFilePath = "";

            Excel.Application excelApplication;
            Excel.Workbooks excelWorkBooks = null;
            Excel.Workbook excelWorkBook = null;
            Excel.Worksheet excelWorkSheet = null;

            try
            {
                excelApplication = new Excel.ApplicationClass();
                excelWorkBooks = excelApplication.Workbooks;
                excelWorkBook = ((Excel.Workbook)excelWorkBooks.Open(FilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets[1];
                excelApplication.Visible = false;
                excelApplication.DisplayAlerts = false;
                _NewFilePath = FilePath.Replace(".csv", ".xls");
                excelWorkBook.SaveAs(_NewFilePath, Excel.XlFileFormat.xlAddIn, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                excelWorkBook.Close();
                QuertExcel();
                // ExcelFormatHelper.DeleteFile(FilePath);
                //可以不用杀掉进程QuertExcel();


                GC.Collect(System.GC.GetGeneration(excelWorkSheet));
                GC.Collect(System.GC.GetGeneration(excelWorkBook));
                GC.Collect(System.GC.GetGeneration(excelApplication));

            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            finally
            {
                GC.Collect();
            }

            return _NewFilePath;
        }



        /// <summary>
        /// 将xls文件转换为csv文件
        /// </summary>
        /// <param name="FilePath">文件全路路径</param>
        /// <returns>返回转换后的csv文件名</returns>
        public static string XLSSavesaCSV(string FilePath)
        {
            QuertExcel();
            string _NewFilePath = "";

            Excel.Application excelApplication;
            Excel.Workbooks excelWorkBooks = null;
            Excel.Workbook excelWorkBook = null;
            Excel.Worksheet excelWorkSheet = null;

            try
            {
                excelApplication = new Excel.ApplicationClass();
                excelWorkBooks = excelApplication.Workbooks;
                excelWorkBook = ((Excel.Workbook)excelWorkBooks.Open(FilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets[1];
                excelApplication.Visible = false;
                excelApplication.DisplayAlerts = false;
                _NewFilePath = FilePath.Replace(".xlsx", ".csv");

                //excelWorkSheet._SaveAs(FilePath, Excel.XlFileFormat.xlCSVWindows, Missing.Value, Missing.Value, Missing.Value,Missing.Value,Missing.Value, Missing.Value, Missing.Value);
                excelWorkBook.SaveAs(_NewFilePath, Excel.XlFileFormat.xlCSV, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                QuertExcel();
                //ExcelFormatHelper.DeleteFile(FilePath);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            return _NewFilePath;
        }



        /// <summary>
        /// 删除一个指定的文件
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns></returns>
        public static bool DeleteFile(string FilePath)
        {
            try
            {
                bool IsFind = File.Exists(FilePath);
                if (IsFind)
                {
                    File.Delete(FilePath);
                }
                else
                {
                    throw new IOException("指定的文件不存在");
                }
                return true;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

        }


        /// <summary>
        /// 执行过程中可能会打开多个EXCEL文件 所以杀掉
        /// </summary>
        private static void QuertExcel()
        {
            Process[] excels = Process.GetProcessesByName("EXCEL");
            foreach (var item in excels)
            {
                item.Kill();
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            //F:\资料\资料\demo\大数据瞬间入库\WebApplication1\Content\客户信息.csv
            //CSVSaveasXLS(textBox1.Text);
            //F:\资料\资料\demo\大数据瞬间入库\WebApplication1\Content\客户信息.xlsx
            //E:\客户信息模板.xlsx
            var aa =  XLSSavesaCSV(textBox1.Text);
            label1.Text = aa;

            //停顿两秒 负责下边读取csv文件会显示占用 关闭不及时
            System.Threading.Thread.Sleep(2000);  //2秒

            var dt= OpenCSV(aa);
            //列名乱码 替换列名  数据处理
            dt.Columns["序号"].ColumnName = "Id";
            //有数据则不能改类型
            //dt.Columns["Id"].DataType = Type.GetType("System.Int32");
            dt.Columns["公司名称"].ColumnName = "Company";
            dt.Columns["公司注册地址"].ColumnName = "Address";
            dt.Columns["公司营业范围"].ColumnName = "Business";
            dt.Columns["注册资金"].ColumnName = "RegCapital";
            dt.Columns["投保人数"].ColumnName = "EmployeesNum";
            dt.Columns["法人姓名"].ColumnName = "Boss";
            dt.Columns["备注"].ColumnName = "Remark";
            dt.Columns.Add("Status", Type.GetType("System.Int32")).SetOrdinal(7);
            dt.Columns.Add("StatusTime", Type.GetType("System.DateTime")).SetOrdinal(8);
            dt.Columns.Add("Type", Type.GetType("System.Int32")).SetOrdinal(9);
            dt.Columns.Add("TypeTime", Type.GetType("System.DateTime")).SetOrdinal(10);
            dt.Columns.Add("Level", Type.GetType("System.String")).SetOrdinal(11);
            dt.Columns.Add("PrePurchase", Type.GetType("System.Decimal")).SetOrdinal(12);
            dt.Columns.Add("Description", Type.GetType("System.String")).SetOrdinal(13);
            dt.Columns.Add("YewuId", Type.GetType("System.Int32")).SetOrdinal(14);
            dt.Columns.Add("YewuName", Type.GetType("System.String")).SetOrdinal(15);
            dt.Columns.Add("IsDel", Type.GetType("System.Int32")).SetOrdinal(16);
            dt.Columns.Add("Createtime",Type.GetType("System.DateTime")).SetOrdinal(18);

            //有数据的列要修改类型进入以下方法
            dt = UpdateDataTable(dt);

            var newCon = "server=127.0.0.1;database=its;uid=sa;pwd=1;";

            SqlBulkCopyInsert(newCon, "MallCustomer", dt);

            //删除.csv文件
           var res= DeleteFile(aa);

            MessageBox.Show("success");
        }

        /// <summary>
        /// 修改数据表DataTable某一列的类型和记录值(正确步骤：1.克隆表结构，2.修改列类型，3.修改记录值，4.返回希望的结果)
        /// </summary>
        /// <param name="argDataTable">数据表DataTable</param>
        /// <returns>数据表DataTable</returns>  
        private DataTable UpdateDataTable(DataTable argDataTable)
        {
            DataTable dtResult = new DataTable();
            //克隆表结构
            dtResult = argDataTable.Clone();
            foreach (DataColumn col in dtResult.Columns)
            {
                //修改列的数据格式  
                switch (col.ColumnName)
                {
                    case "Id":
                        col.DataType = typeof(Int32);
                        break;
                    case "RegCapital":
                        col.DataType = typeof(Decimal);
                        break;
                    case "EmployeesNum":
                        col.DataType = typeof(Int32);
                        break;
                }
            }
            string company = "";
            foreach (DataRow row in argDataTable.Rows)
            {
                DataRow rowNew = dtResult.NewRow();
                rowNew["Id"] =Convert.ToInt32(row["Id"].ToString() == "" ? 0 : row["Id"]).ToString();
                var aaa = row["EmployeesNum"];
                //修改记录值
                rowNew["EmployeesNum"] = Convert.ToInt32(row["EmployeesNum"].ToString()==""?0: row["EmployeesNum"]).ToString();
                var aaa1 = row["RegCapital"];
                rowNew["RegCapital"] = Convert.ToDecimal(row["RegCapital"].ToString() == "" ? 0 : row["RegCapital"]).ToString();
                rowNew["Company"] = row["Company"];
                rowNew["Address"] = row["Address"];
                rowNew["Business"] = row["Business"];
                rowNew["Boss"] = row["Boss"];
                rowNew["Remark"] = row["Remark"];
                rowNew["Status"] = 10;
                rowNew["StatusTime"] = DateTime.Now.ToString();
                rowNew["Type"] =10;
                rowNew["TypeTime"] = DateTime.Now.ToString();
                rowNew["Level"] = row["Level"];
                rowNew["PrePurchase"] = row["PrePurchase"];
                rowNew["Description"] = row["Description"];
                rowNew["YewuId"] = row["YewuId"];
                rowNew["YewuName"] = row["YewuName"];
                rowNew["IsDel"] = 0;
                rowNew["Createtime"] = DateTime.Now.ToString();

                //合并重复项
                if (company == row["Company"].ToString())
                {
                    dtResult.Rows[dtResult.Rows.Count - 1]["Remark"] +=","+ row["Remark"].ToString();
                }
                else
                {
                    dtResult.Rows.Add(rowNew);
                    company = row["Company"].ToString();
                }
            }
            return dtResult;
        }


        /// <summary>
        /// 将CSV文件的数据读取到DataTable中
        /// </summary>
        /// <param name="fileName">CSV文件路径</param>
        /// <returns>返回读取了CSV数据的DataTable</returns>
        public static DataTable OpenCSV(string filePath)
        {
            //中文乱码
            Encoding encoding = Encoding.Default; //Encoding.ASCII;//
            DataTable dt = new DataTable();
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            //StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            StreamReader sr = new StreamReader(fs, encoding);
            //string fileContent = sr.ReadToEnd();
            //encoding = sr.CurrentEncoding;
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                //strLine = Common.ConvertStringUTF8(strLine, encoding);
                //strLine = Common.ConvertStringUTF8(strLine);

                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(tableHead[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(strLine))
                    {
                        aryLine = strLine.Split(',');
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < columnCount; j++)
                        {
                            dr[j] = aryLine[j];
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            if (aryLine != null && aryLine.Length > 0)
            {
                dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            }

            sr.Close();
            fs.Close();
            return dt;
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
