using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class TestController : ApiController
    {
        public void UpLoad()
        {
            var memoryStreamProvide = new MultipartMemoryStreamProvider();
            Request.Content.ReadAsMultipartAsync(memoryStreamProvide);

            foreach (var item in memoryStreamProvide.Contents)
            {
                if (item.Headers.ContentDisposition.FileName != null)
                {
                    var filename = item.Headers.ContentDisposition.FileName.Replace("\"", "");
                    string newFileName = direction + filename;
                    var ms = item.ReadAsStreamAsync().Result;
                    using (var br = new BinaryReader(ms))
                    {
                        var data = br.ReadBytes((int)ms.Length);
                        File.WriteAllBytes(newFileName, data);

                    }
                }
            }
        }
    }
}
