using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            //DataTable dt = new DataTable();//创建表
            //dt.Columns.Add("ID", typeof(Int32));//添加列
            //dt.Columns.Add("Name", typeof(String));
            //dt.Columns.Add("Age", typeof(Int32));
            //dt.Rows.Add(new object[] { 1, "张三", 20 });//添加行
            //dt.Rows.Add(new object[] { 2, "李四", 25 });
            //dt.Rows.Add(new object[] { 3, "王五", 30 });
            DataTable bjDt = new DataTable();
            bjDt.Columns.Add("name", typeof(String));
            bjDt.Rows.Add("参赛运动员身份证号码统计表");
            bjDt.Rows.Add("报名表");
            string tpath = "2019年北京市传统武术冠军赛报名表";
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(String));
            dt.Columns.Add("序号", typeof(int));
            dt.Columns.Add("姓名", typeof(String));
            dt.Columns.Add("身份证号", typeof(String));
            dt.Columns.Add("备注", typeof(String));
            dt.Rows.Add(new object[] { "参赛运动员身份证号码统计表",1,"张三","123456","无"});
            dt.Rows.Add(new object[] { "参赛运动员身份证号码统计表", 2, "李四", "123456", "大大大" });
            dt.Rows.Add(new object[] { "报名表", 3, "王五", "123456", "电器电器多群" });
            var path = ExcelCopyHelper.DataTableToExcel(bjDt,dt, tpath);

            FileDown(path);
            return View();
        }

        public void FileDown(string url)
        {
            string fileName = "test.xls";//客户端保存的文件名
            string filePath = url;//路径

            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }
    }
}