using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public TestController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public Result SaveImg(string str)
        {
            str = str.Substring(22);
            var dir = @"./wwwroot/images/";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            var fileName = Guid.NewGuid();
           var path = dir + fileName+ ".png";
            Base64StringToFile(str, path);
            return new Result() { path= @"\images\" + fileName + ".png", fileName=fileName+".png",code=0 };
        }
        public void Base64StringToFile(string strbase64, string strurl)
        {
            try
            {
                strbase64 = strbase64.Replace(' ', '+');
                MemoryStream stream = new MemoryStream(Convert.FromBase64String(strbase64));
                FileStream fs = new FileStream(strurl, FileMode.OpenOrCreate, FileAccess.Write);
                byte[] b = stream.ToArray();
                //byte[] b = stream.GetBuffer();
                fs.Write(b, 0, b.Length);
                fs.Close();

            }
            catch (Exception e)
            {

            }
        }

        public IActionResult DownImg(string path,string fileName)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            webRootPath = webRootPath+ path;
            var stream = System.IO.File.OpenRead(webRootPath);  //创建文件流
            return File(stream, "image/png", fileName);
        }
    }
    public class Result
    {
        public string path { get; set; }
        public string fileName { get; set; }
        public int code { get; set; }
    }
}