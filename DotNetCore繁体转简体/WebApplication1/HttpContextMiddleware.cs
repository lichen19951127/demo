using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class HttpContextMiddleware
    {
        private readonly RequestDelegate _next;
        public HttpContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //public async Task Invoke(HttpContext context)
        //{
        //    var originalBodyStream = context.Response.Body;

        //    using (var responseBody = new MemoryStream())
        //    {
        //        context.Response.Body = responseBody;
        //        await _next(context);
        //        var result = await FormatResponse(context.Response);
        //        if (context.Request.Headers.Keys.Contains(Constants.HttpHeaderLanguage))
        //        {
        //            var lang = context.Request.Headers.GetCommaSeparatedValues(Constants.HttpHeaderLanguage).GetValue(0).ToString();
        //            if (lang == "zh-tw")
        //            {
        //                var traditionresult = ConvertHelper.ToTraditional(result);
        //                byte[] array = Encoding.UTF8.GetBytes(traditionresult);
        //                MemoryStream stream = new MemoryStream(array);
        //                try
        //                {
        //                    await stream.CopyToAsync(originalBodyStream);
        //                }
        //                catch (Exception ex)
        //                {

        //                    throw ex;
        //                }
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    await responseBody.CopyToAsync(originalBodyStream);
        //                }
        //                catch (Exception ex)
        //                {

        //                    throw ex;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            await responseBody.CopyToAsync(originalBodyStream);
        //        }

        //    }
        //}

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return $"{text}";
        }
    }
}
