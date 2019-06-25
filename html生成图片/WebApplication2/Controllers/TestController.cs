using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Content;
using System.IO;
using System.Drawing.Imaging;

namespace WebApplication2.Controllers
{
    public class TestController : Controller
    {
        #region WebBrowser生成图片
        // GET: Test
        public ActionResult Index(int type=0)
        {
            List<Student> list = new List<Student>();
            for (int i = 0; i < 50; i++)
            {
                Student stu = new Student();
                stu.Id = i + 1;
                stu.Name = "张三"+i.ToString();
                stu.Age = 20 + i;
                list.Add(stu);
            }
            ViewBag.list = list;
            ViewBag.type = type;
            return View();
        }

        public string GetfileName(int width, int height)
        {
            Bitmap m_Bitmap = WebSnapshotsHelper.GetWebSiteThumbnail("http://localhost:64806/Test/Index?type=1", width, height, width, height); //宽高根据要获取快照的网页决定
            var path = Server.MapPath("/Content/img/");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var fileName =Guid.NewGuid()+ ".jpeg";
            m_Bitmap.Save(path + fileName, System.Drawing.Imaging.ImageFormat.Jpeg); //图片格式可以自由控制       
            return fileName;
        }

        public ActionResult DownImg(string fileName)
        {
            var path = Server.MapPath("/Content/img/")+ fileName;
            return File(path, "image/jpeg", fileName);
        }

        public ActionResult Home()
        {
            return View();
        }
        #endregion

        #region
        public ActionResult Test(int id)
        {
            string abc = id == 1 ? "这是图片一" : "这是图片2";
            ViewBag.abc = abc;
            return View();
        }
        /// <summary>
        /// 生成广告图片
        /// </summary>
        /// <param name="id">广告id</param>
        /// <returns></returns>
        [HttpGet]
        public string GenerateAdImage(int id)
        {
            var htmlToImageConv = new NReco.ImageGenerator.HtmlToImageConverter();
            htmlToImageConv.Width = 850;
            var jpegBytes = htmlToImageConv.GenerateImageFromFile("http://localhost:64806/Test/Test?id=" + id, "png");
            string url = "";
            using (var stream = new MemoryStream(jpegBytes))
            {
                var bitmap = new Bitmap(stream);
                using (var nstream = new MemoryStream())
                {
                    var eps = new EncoderParameters();
                    eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, new long[1] { 100 });
                    bitmap.Save(nstream, ImageCodecInfo.GetImageEncoders().FirstOrDefault(x => x.FormatDescription == "PNG"), eps);
                    bitmap.Dispose();
                    string tempfile = @"F:\资料\资料\demo\html生成图片\WebApplication2\Content\img\";
                    if (!Directory.Exists(tempfile))
                        Directory.CreateDirectory(tempfile);
                    var fileName= Guid.NewGuid() + ".png";
                    tempfile += fileName;
                    FileStream file =System.IO.File.Create(tempfile);
                    file.Write(nstream.GetBuffer(), 0, (int)nstream.Length);
                    file.Close();
                    //url = AliyunOSSHelper.OSSUploadImage(tempfile, "", $"upload/mall/ad/{DateTime.Now.ToString("yyyyMM")}");
                    //System.IO.File.Delete(tempfile);
                    url = "/Content/img/" + fileName;
                }
            }
            return url;
        }

        #endregion
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}