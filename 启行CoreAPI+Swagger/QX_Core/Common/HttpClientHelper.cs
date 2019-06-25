using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QX_Core.Common
{
    public static class HttpClientHelper
    {
        /// <summary>
        /// client请求服务器
        /// </summary>
        /// <param name="method">请求方式</param>
        /// <param name="url">请求路径</param>
        /// <param name="content">可选参数</param>
        /// <returns></returns>
        public static string Client(string method, string url, HttpContent content = null)
        {
            HttpResponseMessage response = null;
            string result = string.Empty;
            //实例化一个请求
            HttpClient client = new HttpClient();
            //设置返回值格式
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //判断请求方式
            if (method.ToLower() == "get")
            {
                response = client.GetAsync(url).Result;
            }
            if (method.ToLower() == "post")
            {
                response = client.PostAsync(url, content).Result;
            }
            if (method.ToLower() == "put")
            {
                response = client.PutAsync(url, content).Result;
            }
            if (method.ToLower() == "delete")
            {
                response = client.DeleteAsync(url).Result;
            }
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            //返回结果
            return result;
        }


        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData">post数据</param>
        /// <returns></returns>
        public static string PostResponse(string url, string postData, out string statusCode)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";

            HttpClient httpClient = new HttpClient();
            //httpClient..setParameter(HttpMethodParams.HTTP_CONTENT_CHARSET, "utf-8");

            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }

            return null;
        }
    }
}
