using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Page
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取详情页面的文档结构
            string HtmlTemplateStrDetail = GetProductTemplate("ProductDetail_Template.html");
           //获取列表页面的文档结构
            string HtmlList = GetProductTemplate("ProductList_Template.html");

            #region  数据库数据

            List<News> list = new List<News>();

            News newInfo = new News();


            newInfo.ID = 1;
            newInfo.NewsTitle = "郭宇说我今天的任务没有完成需要迭代？";
            newInfo.Content = "周末估计要加班儿了？";

            News newInfo1 = new News();
            newInfo1.ID = 2;
            newInfo1.NewsTitle = "1603.netN毕业时间是什么时候？";
            newInfo1.Content = "大概是12月底左右吧";

            News newInfo2 = new News();
            newInfo2.ID = 3;
            newInfo2.NewsTitle = "今天讲了静态化页面。。。";
            newInfo2.Content = "很简单";

            News newInfo4 = new News();
            newInfo4.ID = 4;
            newInfo4.NewsTitle = "1603.netN班有人迟到了？。。。";
            newInfo4.Content = "呵呵、我们红牛有着落了。。。。";
            News newInfo5 = new News();
            newInfo5.ID = 5;
            newInfo5.NewsTitle = "今天月考了吗？。。。";
            newInfo5.Content = "理论题竟然和上周的一样 好玩了。。。。。。。";

            list.Add(newInfo);
            list.Add(newInfo1);
            list.Add(newInfo2);
            list.Add(newInfo4);
            list.Add(newInfo5);
            #endregion

            WriteHtmlPage(list, HtmlTemplateStrDetail, 0);
            WriteHtmlPage(list, HtmlList, 1);

            Console.WriteLine("生成完毕");
            Console.ReadKey();
        }

        public static string Url = @"/Users/zhanghaibin/Documents/Visual Studio 2017/Projects/Static_Page/Static_Page/Template/";
        public static string GetProductTemplate(string TemplateName)
        {
            StreamReader sr = new StreamReader(Url + TemplateName, Encoding.GetEncoding("utf-8"));
            string str = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            return str;
        }



        public static void WriteHtmlPage(List<News> list, string Html, int typeID)
        {

            string FileName = "";
            switch (typeID)
            {
                case 0:
                    foreach (News c in list)//遍历单个数据表的列名
                    {
                        FileName = c.ID.ToString() + ".html";
                        string HtmlStr = Html.Replace("#title", c.NewsTitle).Replace("#content", c.Content);
                        StreamWriter sw = new StreamWriter(Url + FileName, false, Encoding.GetEncoding("utf-8"));
                        sw.Write(HtmlStr);
                        sw.Flush();
                        sw.Close();
                    }
                    break;
                case 1:
                    FileName = "Product_List.html";
                    string ListHtml = "";
                    foreach (News n in list)
                    {
                        ListHtml += "<a href=" + n.ID + ".html>" + n.NewsTitle + "</a><br/>";
                    }
                    Html = Html.Replace("#List", ListHtml);
                    StreamWriter sw1 = new StreamWriter(Url + FileName, false, Encoding.GetEncoding("utf-8"));
                    sw1.Write(Html);
                    sw1.Flush();
                    sw1.Close();
                    break;
                default:


                    break;
            }
        }
    }


    class News
    {
        public int ID { get; set; }
        public string NewsTitle { get; set; }
        public string Content { get; set; }

    }
}
