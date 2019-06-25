using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //导入到数据库
           var getDT= ExcelHelper.ImpExcelDt(@"F:\新建 XLS 工作表 (2).xls");
            var rowcount = 0;
            for (int i = 0; i < getDT.Rows.Count; i++)
            {
                var sql = "insert into Users values('";
                sql += getDT.Rows[i].ItemArray[1]+"')";
                rowcount+=DBHelper.ExecuteNonQuery(sql);
            }

            //导入到Excel
            var dt = DBHelper.ExecuteDataSet("select * from Users").Tables[0];
           var result= ExcelHelper.ExportToExcel(dt, @"F:\新建 XLS 工作表.xls", "Users");
            Console.ReadKey();
        }
    }
}
