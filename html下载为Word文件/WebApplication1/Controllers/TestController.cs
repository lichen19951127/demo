using Aspose.Words;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class Info
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ResourceCode { get; set; }
        public string ResourceName { get; set; }
        public int Count { get; set; }
        public int TenderPrice { get; set; }
        public string BidderName { get; set; }
        public string InventoryPlace { get; set; }
        public string Remarks { get; set; }
        public DateTime CreationTime { get; set; }
        public string Unit { get; set; }
    }
    public class TestController : Controller
    {
        /// <summary>
        /// 下载中标通知书
        /// 用法：前端一个a标签指向这个控制器的这个方法
        /// </summary>
        /// <param name="id">中标通知书Id</param>
        //[AbpMvcAuthorize(BiddingNoticeAppPermissions.BiddingNotice)]
        public ActionResult Index()
        {
            long id = 0;
            #region 读取模板 
            var html = GetBidTempStrng();
            #endregion

            #region 根据ID读取中标内容 替换数据
            //var model = _biddingNoticeRepository.FirstOrDefault(id);

            var model = new Info() {
               Id=1,
                BrandName="",
                ResourceCode="",
                ResourceName="",
                Count=100,
                TenderPrice=1000,
                BidderName="",
                InventoryPlace="",
                Remarks="",
                CreationTime=DateTime.Now,
                Unit=""
            };

            model = null;
            if (model != null)
            {
                html = html.Replace("@BrandName", model.BrandName).Replace("@ResourceCode", model.ResourceCode)
                    .Replace("@ResourceName", model.ResourceName).Replace("@Count", model.Count.ToString())
                    .Replace("@TenderPrice", model.TenderPrice.ToString()).Replace("@BidderName", model.BidderName)
                    .Replace("@InventoryPlace", model.InventoryPlace).Replace("@Remarks", model.Remarks)
                    .Replace("@Year", model.CreationTime.Year.ToString()).Replace("@Moth", model.CreationTime.Month.ToString())
                    .Replace("@Day", model.CreationTime.Day.ToString()).Replace("@Unit", model.Unit);
            }
            else
            {
                html = html.Replace("@BrandName", "XXXXX").Replace("@ResourceCode", "ZYXXXXXXXX")
                    .Replace("@ResourceName", "XXXXX").Replace("@Count", "0")
                    .Replace("@TenderPrice", "0").Replace("@BidderName", "XXXXX")
                    .Replace("@InventoryPlace", "XXXXX").Replace("@Remarks", "XXXXXXXX")
                    .Replace("@Year", "XXXX").Replace("@Moth", "XX")
                    .Replace("@Day", "XX").Replace("@Unit", "X");
            }
            #endregion


            #region 转换为Word文档样式
            //System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=result.doc");
            //System.Web.HttpContext.Current.Response.ContentType = "application/msword";
            //System.Web.HttpContext.Current.Response.Charset = "utf-8";
            //System.Web.HttpContext.Current.Response.Write(html);
            //System.Web.HttpContext.Current.Response.End();
            //return View();
            #endregion

            #region 转换为Word文档样式

            //StringBuilder sb = new StringBuilder();
            //sb.Append(
            //    "<html xmlns:v=\"urn:schemas-microsoft-com:vml\"  xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" xmlns:m=\"http://schemas.microsoft.com/office/2004/12/omml\"xmlns = \"http://www.w3.org/TR/REC-html40\">");
            //sb.Append(html);
            //sb.Append("</html>");
            //return File(Encoding.UTF8.GetBytes(sb.ToString()), "application/msword", $"中标通知书.doc");

            #endregion



            html = new Regex("title(.*?)\"(.*?)\"").Replace(html, "");

            html += "<table>" +
                   "<tr>" +
                   "<td>Row 1, Cell 1</td>" +
                   "<td>Row 1, Cell 2</td>" +
                   "</tr>" +
                   "<tr>" +
                   "<td>Row 2, Cell 2</td>" +
                   "<td>Row 2, Cell 2</td>" +
                   "</tr>" +
                   "</table>";
            //生成word
            Document _doc = new Document();
            DocumentBuilder _builder = new DocumentBuilder(_doc);
            _builder.InsertHtml(html);
            _doc.Save("F://text.docx", Aspose.Words.SaveFormat.Docx);

         
            //檔案下載
            //把檔案讀進串流
            FileStream fs = new FileStream("F://text.docx", FileMode.Open);
            byte[] file = new byte[fs.Length];
            fs.Read(file, 0, file.Length);
            fs.Close();
            var fileNameWithOutExtention = "test";
            //Response給用戶端下載
           System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ContentType = "application/msword";
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileNameWithOutExtention + ".docx");//強制下載
            System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
            System.Web.HttpContext.Current.Response.BinaryWrite(file);

            Response.End();
            return View();
        }

        /// <summary>
        /// 读取中标通知书模板
        /// </summary>
        /// <returns></returns>
        private string GetBidTempStrng()
        {
            StringBuilder sbHtml = new StringBuilder();
            // 读取模板替换数据
            var path = Server.MapPath("~/Common/BidTemplace/BidTemp.html");
            using (Stream inStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader outStream = new StreamReader(inStream, Encoding.Default))
            {
                while (!outStream.EndOfStream)
                {
                    sbHtml.Append(outStream.ReadLine());
                }
            }
            var html = sbHtml.ToString();
            return html;
        }


        public ActionResult test()
        {
            CreateDocx("","");
            return View();
        }
        public static void CreateDocx(string url, string filename)
        {
            //Open document and create Documentbuilder
            Aspose.Words.Document doc = new Aspose.Words.Document("F://demo.doc");
            DocumentBuilder builder = new DocumentBuilder(doc);
            //Set table formating
            //Set borders
            builder.CellFormat.Borders.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Color = Color.Red;
            //Set left indent
            builder.RowFormat.LeftIndent = 100;
            // etc...
            //Move documentBuilder cursor to the bookmark
            builder.MoveToBookmark("myBookmark");
            //Insert some table
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    builder.InsertCell();
                    builder.Write("this is cell");
                }
                builder.EndRow();
            }
            builder.EndTable();
            //Save output document
            doc.Save("F://demo2.doc");

            //Aspose.Words.Document wordDoc = new Aspose.Words.Document();
            //DocumentBuilder builder = new DocumentBuilder(wordDoc);
            ////string html = GetWebClient(url);
            //builder.InsertHtml("<table>" +
            //       "<tr>" +
            //       "<td>Row 1, Cell 1</td>" +
            //       "<td>Row 1, Cell 2</td>" +
            //       "</tr>" +
            //       "<tr>" +
            //       "<td>Row 2, Cell 2</td>" +
            //       "<td>Row 2, Cell 2</td>" +
            //       "</tr>" +
            //       "</table>");
            //wordDoc.Save(filename, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Docx));
        }




    }
}