using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp3
{
    public class Info
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<Info> list = new List<Info>();

        }

        #region  NPOI大数据量多个sheet导出

        /// <summary>
        /// 大数据量多个sheet导出
        /// </summary>
        /// <typeparam name="T">数据源实体类</typeparam>
        /// <param name="objList">数据源</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="btyBytes">导出数据流</param>
        /// <param name="columnInfo">显示列对应数据字典</param>
        /// <param name="listCount">每个sheet包含数据条数</param>
        /// <returns></returns>
        public static bool ExportExcelTest<T>(List<T> objList, string fileName, ref byte[] btyBytes,
Dictionary<string, string> columnInfo = null, int listCount = 10000)
        {
            bool bResult = false;
            //在内存中生成一个Excel文件：
            XSSFWorkbook book = new XSSFWorkbook();
            if (objList != null && objList.Count > 0)
            {
                double sheetCount = Math.Ceiling((double)objList.Count / listCount);
                for (int i = 0; i < sheetCount; i++)
                {
                    ISheet sheet = null;
                    sheet = book.CreateSheet("sheet" + i);
                    sheet.DefaultRowHeight = 20 * 10;
                    List<T> list = new List<T>();
                    list = objList.Skip<T>(listCount * i).Take<T>(listCount).ToList();

                    int rowIndex = 0;
                    int StartColIndex = 0;
                    int colIndex = StartColIndex;

                    //创建表头样式
                    ICellStyle style = book.CreateCellStyle();
                    style.Alignment = HorizontalAlignment.CENTER;
                    style.WrapText = true;
                    IFont font = book.CreateFont();
                    font.FontHeightInPoints = 16;
                    font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;
                    font.FontName = "简体中文";
                    style.SetFont(font);//HEAD 样式

                    Type myType = null;
                    myType = objList[0].GetType();
                    //根据反射从传递进来的属性名信息得到要显示的属性
                    List<PropertyInfo> myPro = new List<PropertyInfo>();
                    PropertyInfo[] properties = myType.GetProperties();

                    #region 定义表头
                    int m = 0;
                    if (columnInfo != null)
                    {
                        var rowheader = sheet.CreateRow(0);
                        rowheader.Height = rowheader.Height = 20 * 20;
                        foreach (string cName in columnInfo.Keys)
                        {
                            PropertyInfo p = myType.GetProperty(cName);
                            if (p != null)
                            {
                                myPro.Add(p);
                                rowheader.CreateCell(m).SetCellValue(columnInfo[cName]);
                                m++;
                            }
                        }
                    }
                    #endregion
                    #region 定义表体并赋值
                    //如果没有找到可用的属性则结束
                    if (myPro.Count == 0) { return bResult; }
                    foreach (T obj in list)
                    {
                        int n = 0;
                        if (sheet != null)
                        {
                            rowIndex++;
                            var sheetrow = sheet.CreateRow(rowIndex);
                            sheetrow.Height = sheetrow.Height = 20 * 20;
                            foreach (PropertyInfo p in myPro)
                            {
                                dynamic val = p.GetValue(obj, null) ?? "";
                                string valtype = val.GetType().ToString();
                                if (valtype.ToLower().IndexOf("decimal", StringComparison.Ordinal) > -1)
                                {
                                    val = Convert.ToDouble(val);
                                }
                                else if (valtype.ToLower().IndexOf("datetime", StringComparison.Ordinal) > -1)
                                {
                                    val = val.ToString("yyyy-MM-dd HH:mm:ss");
                                    if (val.Equals("0001-01-01 00:00:00"))
                                    {
                                        val = "";
                                    }
                                }
                                sheetrow.CreateCell(n).SetCellValue(val);
                                n++;
                            }
                        }

                    }
                    #endregion
                }
            }
            else
            {
                //在工作薄中建立工作表
                XSSFSheet sheet = book.CreateSheet() as XSSFSheet;
                sheet.SetColumnWidth(0, 30 * 256);
                if (sheet != null) sheet.CreateRow(0).CreateCell(0).SetCellValue("暂无数据！");
            }

            try
            {
                HttpResponse rs = System.Web.HttpContext.Current.Response;
                rs.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
                rs.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
                rs.ContentType = "application/ms-excel";
                using (MemoryStream ms = new MemoryStream())
                {
                    book.Write(ms);
                    rs.BinaryWrite(ms.ToArray());
                    ms.Flush();
                }
            }
            catch (SystemException ex)
            {
                Console.WriteLine("异常"+ex);
                //LogHelper.Write(ex);
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("异常" + ex);
                //LogHelper.Write(ex);
            }
            return bResult;
        }


        #endregion
    }
}
