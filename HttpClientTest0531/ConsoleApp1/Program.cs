using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// 直接爬取网站内容
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
          var json=  Client.GetApi("get", "10956667.html");



        //< h1 class = "postTitle">
        //<a id = "cb_post_title_url" class="postTitle2" href="https://www.cnblogs.com/LiChen19951127/p/10956667.html">测试</a>
        //</h1>
        //<div class="clear"></div>
        //<div class="postBody">
        //<div id = "cnblogs_post_body" class="blogpost-body"><p>测试一下</p>
        //<p>测试二下</p>
        //<p>测试三下</p></div><div id = "MySignature" ></ div >
        //< div class="clear"></div>
        //<div id = "blog_post_info_block" >
        //< div id="BlogPostCategory"></div>
        //<div id = "EntryTag" ></ div >
        //< div id="blog_post_info">
        //</div>
        //<div class="clear"></div>
        //<div id = "post_next_prev" ></ div >
        //</ div >
        }
    }
}
