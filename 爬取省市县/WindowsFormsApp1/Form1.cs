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
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var html = GetHtml("http://www.mca.gov.cn/article/sj/xzqh/2019/201901-06/201905271021.html");

            var key = @"<td class=xl7019750>\S\d*</td>";
            var values=@"<td class=xl7019750>\S[\u4e00-\u9fa5]*</td>";

            var aa= GetPathPoint(html, key);

            var bb= GetPathPoint(html, values).ToList();
            string[] cc = new string[] { "","","","","","",""};
            cc.ToList();
            bb.AddRange(cc);
            bb.ToArray();   
            DataTable dt = new DataTable();
            dt.Columns.Add("id", Type.GetType("System.Int32"));
            dt.Columns.Add("name", Type.GetType("System.String"));
            for (int i = 0; i < aa.Length; i++)
            {
                dt.Rows.Add(new object[] { aa[i], bb[i] });
            }

            ExcelHelper.DataTableToExcel(dt,"sheet1",true, @"F:\123.xlsx");


        }


        public static string GetHtml(string url)
        {
            string res = "";
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            res = sr.ReadToEnd();
            sr.Close();
            client.Dispose();
            return res;
        }
        /// <summary>
        /// 截取字符串中指定标签内的内容
        /// </summary>
        /// <param name="Content">需要截取的字符串</param>
        /// <param name="start">开始标签</param>
        /// <param name="end">结束标签</param>
        /// <returns></returns>
        public string GetStr(string Content, string start, string end)
        {
            var posStart = Content.IndexOf(start);
            var posEnd = Content.IndexOf(end);
            return Content.Substring(posStart, (posEnd - posStart + end.Length));
        }


        /// <summary>
        /// 获取正则表达式匹配结果集
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="regx">正则表达式</param>
        /// <returns></returns>
        private string[] GetPathPoint(string value, string regx)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            bool isMatch = System.Text.RegularExpressions.Regex.IsMatch(value, regx);
            if (!isMatch)
                return null;
            System.Text.RegularExpressions.MatchCollection matchCol = System.Text.RegularExpressions.Regex.Matches(value, regx);
            string[] result = new string[matchCol.Count];
            if (matchCol.Count > 0)
            {
                for (int i = 0; i < matchCol.Count; i++)
                {
                    result[i] =matchCol[i].Value.Replace("<td class=xl7019750>", "").Replace("</td>","");
                }
            }
            return result;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var aa = XLSSavesaCSV(@"F:\123.xlsx");

            //让主线程停顿两秒 负责下边读取csv文件太快会显示占用 
            System.Threading.Thread.Sleep(2000);  //2秒

            var dt = OpenCSV(aa);

            dt.Columns["行政区划代码"].ColumnName = "id";
            dt.Columns["单位名称"].ColumnName = "name";
            dt.Columns["父级"].ColumnName = "parentId";
            var newCon = "server=127.0.0.1;database=its;uid=sa;pwd=1;";

            SqlBulkCopyInsert(newCon, "Areas", dt);

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

        /// <summary>
        /// 将CSV文件的数据读取到DataTable中
        /// </summary>
        /// <param name="fileName">CSV文件路径</param>
        /// <returns>返回读取了CSV数据的DataTable</returns>
        public static DataTable OpenCSV(string filePath)
        {
            //中文乱码 如果乱码 可以改下编码格式
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
                //这里可能会报一些数据类型的错误,有以下几种解决办法
                //1.DataTable的数据类型要与数据库一致,列的顺序,列名大小写都要一致
                //2.数据太长,如数据库类型是varchar(50),当前数据太长超过50就会报错,可以修改数据库类型

                throw (ex);
            }
        }
        #endregion
    }
}
