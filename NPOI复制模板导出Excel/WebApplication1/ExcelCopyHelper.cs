using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public static class ExcelCopyHelper
    {
        /// <summary>
        /// 复制sheet
        /// </summary>
        /// <param name="bjDt">sheet名集合</param>
        /// <param name="modelfilename">模板附件名</param>
        /// <param name="tpath">生成文件路径</param>
        /// <returns></returns>
        public static HSSFWorkbook SheetCopy(DataTable bjDt, string modelfilename, out string tpath)
        {
            string templetfilepath = @"F:\资料\资料\demo\NPOI复制模板导出Excel\WebApplication1\files\" + modelfilename + ".xls";//模版Excel

            tpath = @"F:\资料\资料\demo\NPOI复制模板导出Excel\WebApplication1\files\download\" + modelfilename + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xls";//中介Excel，以它为中介来导出，避免直接使用模块Excel而改变模块的格式
            FileInfo ff = new FileInfo(tpath);
            if (ff.Exists)
            {
                ff.Delete();
            }
            FileStream fs = File.Create(tpath);//创建中间excel
            HSSFWorkbook x1 = new HSSFWorkbook();
            x1.Write(fs);
            fs.Close();
            FileStream fileRead = new FileStream(templetfilepath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(fileRead);
            FileStream fileSave2 = new FileStream(tpath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook book2 = new HSSFWorkbook(fileSave2);
            HSSFWorkbook[] book = new HSSFWorkbook[2] { book2, hssfworkbook };
            HSSFSheet CPS = hssfworkbook.GetSheet("参赛运动员身份证号码统计表") as HSSFSheet;//获得模板sheet
            string rsbh = bjDt.Rows[0]["name"].ToString();
            CPS.CopyTo(book2, rsbh, true, true);//将模板sheet复制到目标sheet
            HSSFSheet sheet = book2.GetSheet(bjDt.Rows[0]["name"].ToString()) as HSSFSheet;//获得当前sheet
            for (int i = 1; i < bjDt.Rows.Count; i++)
            {
                sheet.CopySheet(bjDt.Rows[i]["name"].ToString(), true);//将sheet复制到同一excel的其他sheet上
            }
            return book2;
        }
        /// <summary>
        /// 将datatable数据导出到excel
        /// </summary>
        /// <param name="bjDt">sheet名集合</param>
        /// <param name="stuDt">填充数据</param>
        /// <param name="modelfilename">模板名</param>
        /// <returns></returns>
        public static string DataTableToExcel(DataTable bjDt, DataTable stuDt, string modelfilename)
        {
            string path = "";
            HSSFWorkbook book2 = SheetCopy(bjDt, modelfilename, out path);
            for (int j = 0; j < bjDt.Rows.Count; j++)
            {
                HSSFSheet sheets = book2.GetSheet(bjDt.Rows[j]["name"].ToString()) as HSSFSheet;
                sheets.GetRow(1).GetCell(1).SetCellValue(bjDt.Rows[j]["name"].ToString());
                DataRow[] strDt = stuDt.Select(" name='" + bjDt.Rows[j]["name"].ToString() + "'");//筛选出对应的工作表下的数据
                int rowIndex = 4;
                for (int i = 0; i < strDt.Length; i++)
                {
                    HSSFRow row0 = sheets.GetRow(rowIndex) as HSSFRow;  //第几行
                    HSSFCell cell0 = row0.GetCell(0) as HSSFCell;   //第几列
                    cell0.SetCellValue(strDt[i]["序号"].ToString()); //数据填充
                    rowIndex++;
                }
            }
            using (FileStream fileSave = new FileStream(path, FileMode.Open, FileAccess.Write))
            {
                book2.Write(fileSave);
            }
            return path;
        }
    }
}