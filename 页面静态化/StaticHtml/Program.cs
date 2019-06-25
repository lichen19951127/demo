using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取详情页
            string htmlPage = GetHtml("Page.html");
            //获取集合页
            string htmlList = GetHtml("List.html");

            List<Infos> list = new List<Infos>();

            Infos info1 = new Infos();
            info1.Id = 1;
            info1.Title = "海强吃饭了";
            info1.Content = "11111111";
            Infos info2 = new Infos();
            info2.Id = 2;
            info2.Title = "丹丹11111";
            info2.Content = "222222";
            Infos info3 = new Infos();
            info3.Id = 3;
            info3.Title = "马蹄子33333";
            info3.Content = "33333";

            list.Add(info1);
            list.Add(info2);
            list.Add(info3);

            WriteHtml(list, htmlPage, 0);
            WriteHtml(list, htmlList, 1);

            Console.WriteLine("生成完毕");
            Console.ReadKey();
        }

        public static string Url = @"F:\14.大实训\demo\页面静态化\StaticHtml\MasterPage\";


        /// <summary>
        ///根据html名称获取页面元素文本
        /// </summary>
        /// <param name="htmlName">文件名</param>
        /// <returns>返回页面string</returns>
        public static string GetHtml(string htmlName)
        {
            StreamReader stream = new StreamReader(Url+ htmlName, Encoding.GetEncoding("utf-8"));
            var str=stream.ReadToEnd();
            stream.Close();
            stream.Dispose();
            return str;
        }

        public static void WriteHtml(List<Infos> list, string html, int typeId)
        {
            string fileName = "";
            switch (typeId)
            {
                case 0:
                    foreach (Infos i in list)
                    {
                        fileName = i.Id.ToString() + ".html";
                        string htmlStr = html.Replace("#title", i.Title).Replace("#Content",i.Content);
                        StreamWriter streamWriter = new StreamWriter(Url+ fileName, false, Encoding.GetEncoding("utf-8"));
                        streamWriter.Write(htmlStr);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                    break;
                case 1:
                    fileName = "InfosPage.html";
                    string listHtml = "";

                    foreach (Infos i in list)
                    {
                        listHtml += "<a href=" + i.Id + ".html>" + i.Title + "</a><br/>";
                    }

                    string htmlStr1 = html.Replace("#List", listHtml);
                    StreamWriter streamWriter1 = new StreamWriter(Url + fileName, false, Encoding.GetEncoding("utf-8"));
                    streamWriter1.Write(htmlStr1);
                    streamWriter1.Flush();
                    streamWriter1.Close();
                    break;
            }
        }

    }
    public class Infos
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
