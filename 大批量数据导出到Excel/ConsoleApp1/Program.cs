using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        public static Microsoft.Office.Interop.Excel.Application m_xlApp = null;

        static void Main(string[] args)
        {
           DataTabletoExcel(createTable(), "asdsadsadasw");
        }

        public static System.Data.DataTable createTable()
        {
            DataSet ds = new DataSet();
            using (System.Data.DataTable dt = new System.Data.DataTable("students"))
            {
                //创建列
                DataColumn dtc = new DataColumn("姓名", typeof(string));
                dt.Columns.Add(dtc);

                dtc = new DataColumn("性别", typeof(string));
                dt.Columns.Add(dtc);

                dtc = new DataColumn("电话", typeof(Int32));
                dt.Columns.Add(dtc);

                //添加数据到DataTable
                DataRow dr = dt.NewRow();
                dr["姓名"] = "张三";
                dr["性别"] = "男";
                dr["电话"] = 54531;
                dt.Rows.Add(dr);

                dr = dt.NewRow();

                dr["姓名"] = "李四";
                dr["性别"] = "男";
                dr["电话"] = 5731;
                dt.Rows.Add(dr);

                dr = dt.NewRow();

                dr["姓名"] = "王五";
                dr["电话"] = 5868451;
                dr["性别"] = "女";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
            }

            return ds.Tables[0];
        }

        /// <summary>
        /// 将DataTable数据导出到Excel表
        /// </summary>
        /// <param name="dtTmp">要导出的DataTable</param>
        /// <param name="filePath">Excel的保存路径及名称</param>
        public static void DataTabletoExcel(System.Data.DataTable dtTmp, string filePath)
        {
            if (dtTmp == null)
            {
                return;
            }
            long rowNum = dtTmp.Rows.Count;//行数
            int columnNum = dtTmp.Columns.Count;//列数
            m_xlApp = new Microsoft.Office.Interop.Excel.Application();
            m_xlApp.DisplayAlerts = false;//不显示更改提示
            m_xlApp.Visible = false;

            Workbooks workbooks = m_xlApp.Workbooks;
            Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
           Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得Sheet1

            try
            {
                //单张Excel表格最大行数
                if (rowNum > 65536)
                {
                    long pageRows = 65535;  //定义每页显示的行数,行数必须小于65536
                    int scount = (int)(rowNum / pageRows);  //导出数据生成的表单数
                    if (scount * pageRows < rowNum) //当总行数不被pageRows整除时，经过四舍五入可能页数不准
                    {
                        scount = scount + 1;
                    }
                    for (int sc = 1; sc <= scount; sc++)
                    {
                        if (sc > 3) //这里由1改为3，20140922
                        {
                            object missing = System.Reflection.Missing.Value;
                            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(
                                        missing, missing, missing, missing);    //添加一个sheet
                        }
                        else
                        {
                            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[sc];   //取得sheet1
                        }
                        string[,] datas = new string[pageRows + 1, columnNum];

                        for (int i = 0; i < columnNum; i++) //写入字段
                        {
                            datas[0, i] = dtTmp.Columns[i].Caption; //表头信息
                        }
                        Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, columnNum]);
                        range.Interior.ColorIndex = 15; //15代表灰色
                        range.Font.Bold = true;
                        range.Font.Size = 9;

                        int init = int.Parse(((sc - 1) * pageRows).ToString());
                        int r = 0;
                        int index = 0;
                        int result;
                        if (pageRows * sc >= rowNum)
                        {
                            result = (int)rowNum;
                        }
                        else
                        {
                            result = int.Parse((pageRows * sc).ToString());
                        }

                        for (r = init; r < result; r++)
                        {
                            index = index + 1;
                            for (int i = 0; i < columnNum; i++)
                            {
                                object obj = dtTmp.Rows[r][dtTmp.Columns[i].ToString()];
                                datas[index, i] = obj == null ? "" : obj.ToString().Trim();
                            }
                        }

                        Microsoft.Office.Interop.Excel.Range fchR = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[index + 1, columnNum]);
                        fchR.Value2 = datas;
                        worksheet.Columns.EntireColumn.AutoFit();   //列宽自适应。
                        m_xlApp.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized;  //Sheet表最大化
                        range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[index + 1, columnNum]);
                        range.Font.Size = 9;
                        range.RowHeight = 14.25;
                        range.Borders.LineStyle = 1;
                        range.HorizontalAlignment = 1;
                    }
                }
                else
                {
                    string[,] datas = new string[rowNum + 1, columnNum];
                    for (int i = 0; i < columnNum; i++) //写入字段
                    {
                        datas[0, i] = dtTmp.Columns[i].Caption;
                    }
                    Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, columnNum]);
                    range.Interior.ColorIndex = 15;     //15代表灰色
                    range.Font.Bold = true;
                    range.Font.Size = 9;

                    int r = 0;
                    for (r = 0; r < rowNum; r++)
                    {
                        for (int i = 0; i < columnNum; i++)
                        {
                            object obj = dtTmp.Rows[r][dtTmp.Columns[i].ToString()];
                            datas[r + 1, i] = obj == null ? "" : obj.ToString().Trim();
                        }
                    }
                    Microsoft.Office.Interop.Excel.Range fchR = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rowNum + 1, columnNum]);
                    fchR.Value2 = datas;

                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。
                    m_xlApp.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized;

                    range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rowNum + 1, columnNum]);
                    range.Font.Size = 9;
                    range.RowHeight = 14.25;
                    range.Borders.LineStyle = 1;
                    range.HorizontalAlignment = 1;
                }
                workbook.Saved = true;
                workbook.SaveCopyAs(filePath);

                MessageBox.Show("导出成功！" + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出异常：" + ex.Message);
            }
            finally
            {
                EndReport();
            }
        }
        /// <summary>
        /// 退出报表时关闭Excel和清理垃圾Excel进程
        /// </summary>
        private static void EndReport()
        {
            object missing = System.Reflection.Missing.Value;
            try
            {
                m_xlApp.Workbooks.Close();
                m_xlApp.Workbooks.Application.Quit();
                m_xlApp.Application.Quit();
                m_xlApp.Quit();
            }
            catch
            {

            }
            finally
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp.Workbooks);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp.Application);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp);
                    m_xlApp = null;
                }
                catch
                {

                }
                try
                {
                    //清理垃圾进程
                    killProcessThread();
                }
                catch
                {

                }
                GC.Collect();
            }
        }

        /// <summary>
        /// 杀掉不死进程
        /// </summary>
        private static void killProcessThread()
        {
            ArrayList myProcess = new ArrayList();
            for (int i = 0; i < myProcess.Count; i++)
            {
                try
                {
                    System.Diagnostics.Process.GetProcessById(int.Parse((string)myProcess[i])).Kill();
                }
                catch
                {
                }
            }
        }

    }
}