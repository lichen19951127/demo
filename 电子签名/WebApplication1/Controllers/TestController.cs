using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadSignature()
        {
            string imgData = HttpContext.Request.Form["imgData"].ToString();
            var result = new Dictionary<string, object>();
            bool Success = false;
            string Message = "";
            try
            {
                var dir = @"./wwwroot/Signature/";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                var fileName = Guid.NewGuid();

                var path = dir + fileName + ".jpg";

                //using (var fileStream = new FileStream(path, FileMode.Create))
                //{
                //    await file.CopyToAsync(fileStream);
                //    await fileStream.FlushAsync();
                //}

                byte[] arr = Convert.FromBase64String(imgData);
                MemoryStream ms = new MemoryStream(arr);
                await ms.FlushAsync();
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Close();
                Success = true;
                Message = path.Replace("./wwwroot", string.Empty);
            }
            catch (Exception ex)
            {
                Success = false;
                Message = ex.Message;
            }
            result.Add("success", Success);
            result.Add("message", Message);
            return Json(result);
        }
    }
}