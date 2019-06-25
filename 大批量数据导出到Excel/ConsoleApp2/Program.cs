using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using SCFBaseLib;
//using TYYW.AGTJ.Common;
using System.Drawing;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        #region 导出SourceGrid数据（最新版，批量快速输出）
        /// <summary>
        /// 导出SourceGrid数据
        /// </summary>
        /// <param name="grid">SourceGrid</param>
        /// <param name="rowsStr">需要导出的行</param>
        /// <param name="colsStr">需要导出的列</param>
        //Excel导出的时候有两种软件插件可以使用（一种是office一种wps），因为各个插件的dll使用的方法不一样，因此要判断用户安装了哪个软件。
        public static void NewExportSourceGridCell(SourceGrid.Grid grid, List<int> rowsStr, List<int> colsStr)
        {

            //个人做的是政府项目，讲究国产化，在这里我先判断用户是否安装了wps。
            string excelType = "wps";
            Type type;
            type = Type.GetTypeFromProgID("ET.Application");//V8版本类型
            if (type == null)//没有安装V8版本
            {
                type = Type.GetTypeFromProgID("Ket.Application");//V9版本类型
                if (type == null)//没有安装V9版本
                {
                    type = Type.GetTypeFromProgID("Kwps.Application");//V10版本类型
                    if (type == null)//没有安装V10版本
                    {
                        type = Type.GetTypeFromProgID("EXCEL.Application");//MS EXCEL类型
                        excelType = "office";
                        if (type == null)
                        {
                            ModuleBaseUserControl.ShowError("检测到您的电脑上没有安装office或WSP软件，请先安装！");
                            return;//没有安装Office软件
                        }
                    }
                }
            }
            if (excelType == "wps")
            {
                WpsExcel(type, grid, rowsStr, colsStr);
            }
            else
            {
                OfficeExcel(type, grid, rowsStr, colsStr);
            }
        }



        //安装了wps
        public static void WpsExcel(Type type, SourceGrid.Grid grid, List<int> rowsStr, List<int> colsStr)
        {
            dynamic _app = Activator.CreateInstance(type);  //根据类型创建App实例
            dynamic _workbook;  //声明一个文件
            _workbook = _app.Workbooks.Add(Type.Missing); //创建一个Excel
            ET.Worksheet objSheet; //声明Excel中的页
            objSheet = _workbook.ActiveSheet;  //创建一个Excel
            ET.Range range;
            try
            {
                range = objSheet.get_Range("A1", Missing.Value);
                object[,] saRet = new object[rowsStr.Count, colsStr.Count];  //声明一个二维数组
                for (int iRow = 0; iRow < rowsStr.Count; iRow++)  //把sourceGrid中的数据组合成二维数组
                {
                    int row = rowsStr[iRow];
                    for (int iCol = 0; iCol < colsStr.Count; iCol++)
                    {
                        int col = colsStr[iCol];
                        saRet[iRow, iCol] = grid[row, col].Value;
                    }
                }
                range.set_Value(ET.ETRangeValueDataType.etRangeValueDefault, saRet);  //把组成的二维数组直接导入range
                _app.Visible = true;
                _app.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                MessageBox.Show(errorMessage, "Error");
            }
        }

        //安装了office
        public static void OfficeExcel(Type type, SourceGrid.Grid grid, List<int> rowsStr, List<int> colsStr)
        {
            dynamic _app = new Microsoft.Office.Interop.Excel.Application();
            dynamic _workbook;
            _workbook = _app.Workbooks.Add(true);
            _Worksheet objSheet;
            objSheet = _workbook.ActiveSheet;
            Range range;
            try
            {
                range = objSheet.get_Range("A1", Missing.Value);
                range = range.get_Resize(rowsStr.Count, colsStr.Count);
                object[,] saRet = new object[rowsStr.Count, colsStr.Count];
                for (int iRow = 0; iRow < rowsStr.Count; iRow++)
                {
                    int row = rowsStr[iRow];
                    for (int iCol = 0; iCol < colsStr.Count; iCol++)
                    {
                        int col = colsStr[iCol];
                        saRet[iRow, iCol] = grid[row, col].Value;
                    }
                }
                range.set_Value(Missing.Value, saRet);
                _app.Visible = true;
                _app.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                MessageBox.Show(errorMessage, "Error");
            }
        }
        #endregion

    }
}


