using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 上传文件转二进制.Content;

namespace 上传文件转二进制.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void UploadFile()
        {
            var file = Request.Files[0];
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "压缩文件|*.zip;*.jar";//文件扩展名
            //dialog.CheckFileExists = true;
            //dialog.ShowDialog();
            if (!string.IsNullOrEmpty(file.FileName))//可以上传压缩包.zip 或者jar包
            {
                try
                {
                    var path = Server.MapPath("/img/");
                    var newPath= Path.Combine(path, file.FileName);
                    file.SaveAs(newPath);
                    byte[] byteArray = FileBinaryConvertHelper.File2Bytes(newPath);//文件转成byte二进制数组
                    string JarContent = Convert.ToBase64String(byteArray);//将二进制转成string类型，可以存到数据库里面了                                   
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}