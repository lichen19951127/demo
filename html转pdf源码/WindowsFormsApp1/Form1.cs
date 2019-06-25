using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Chushihua();
        }
        public Form1(string[] args)
        {
            Chushihua();
            ConvertToImg(args[0]);
        }

        private void Chushihua()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(2000);

                    if (dateTime != null)
                    {
                        if ((DateTime.Now - ((DateTime)dateTime)).TotalSeconds > 6)
                        {
                            //如果五秒了网页还是没有加载完成，就强制生成。
                            WebBrowserDocumentCompleted d1 = () =>
                            {
                                webBrowser_DocumentCompleted(null, null);
                            };
                            this.Invoke(d1);
                        }
                    }

                }
            }));
            thread.IsBackground = true;
            thread.Start();

            SetWebBrowserFeatures(11);
            InitializeComponent();
        }

        //网页控件
        private static WebBrowser webBrowser = null;
        //标识是否重复打开
        private static bool isOpen;
        //最初加载时间 
        private static DateTime? dateTime = null;

        public void ConvertToImg(string url)
        {
            dateTime = DateTime.Now;

            webBrowser = new WebBrowser();

            //是否显式滚动条
            webBrowser.ScrollBarsEnabled = false;

            webBrowser.Width = 1200;

            //加载HTML页面的地址
            webBrowser.Navigate(url);

            //页面加载完成执行事件
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
        }

        private delegate void WebBrowserDocumentCompleted();
        private void button1_Click(object sender, EventArgs e)
        {
            ConvertToImg(this.textBox1.Text);
        }


        private void webBrowser_DocumentCompleted(object sender, EventArgs e)//这个就是当网页载入完毕后要进行的操作
        {
            if (isOpen)
            {
                //已经打开了就不要生成了，强行关闭。
                Application.Exit();
                return;
            }
            else
            {
                isOpen = true;
            }
            //等待两秒再去生成
            Task.Delay(2000).Wait();

            //获取解析后HTML的大小
            System.Drawing.Rectangle rectangle = webBrowser.Document.Body.ScrollRectangle;
            int width = rectangle.Width;
            int height = rectangle.Height;

            //设置解析后HTML的可视区域
            webBrowser.Width = width;
            webBrowser.Height = height;

            Bitmap bitmap = new System.Drawing.Bitmap(width, height);
            webBrowser.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, width, height));
            webBrowser.Dispose();

            //设置图片文件保存路径和图片格式，格式可以自定义
            string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}SaveFIle\\";
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            var bitList = UpdateImgToList(bitmap);
            bitmap.Dispose();

            ////多张图片按照顺序从上到下合并
            var xing = SynthesisImg(bitList);
            filePath = $"{filePath}{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.png";
            xing.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            xing.Dispose();

            byte[] result = CreatePDF(bitList, width);

            //创建PDF
            string pdfPath = $"{AppDomain.CurrentDomain.BaseDirectory}SaveFIle\\{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.pdf";
            FileStream fileStream = new FileStream(pdfPath, FileMode.Create);
            fileStream.Write(result, 0, result.Length);

            fileStream.Dispose();

            System.Diagnostics.Process.Start("explorer", $"/select,{new FileInfo(pdfPath).FullName}");

            Application.Exit();
        }

        public byte[] CreatePDF(List<Bitmap> bitmaps, int width)
        {
            using (MemoryStream ms = new MemoryStream())
            using (Document doc = new Document(new iTextSharp.text.Rectangle(0, 0, width, 14400)/*左右上下*/, 0, 0, 0, 0))
            using (PdfWriter writer = PdfWriter.GetInstance(doc, ms))
            {
                writer.CloseStream = false;

                doc.Open();

                foreach (var bitmap in bitmaps)
                {
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Png);

                    img.ScalePercent(100);      // 放缩比例

                    doc.Add(img);       // 添加图片对像

                    if (bitmap != bitmaps.Last())
                    {
                        //不是最后一页才要创建新页
                        doc.NewPage();
                    }


                    bitmap.Dispose();
                }

                doc.Close();
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 把图片分割成多个笑图片
        /// </summary>
        /// <param name="bitmap">要分割的图片</param>
        /// <param name="maxHeight">分割的高度</param>
        /// <returns></returns>
        private List<Bitmap> UpdateImgToList(Bitmap bitmap, int maxHeight = 14400)
        {
            List<Bitmap> result = new List<Bitmap>();

            int width = bitmap.Width;
            int height = bitmap.Height;

            int pages = height / maxHeight;
            if ((height % maxHeight) != 0)
            {
                pages += 1;
            }

            for (int i = 1; i <= pages; i++)
            {
                int newImgHeight = maxHeight;
                int newImgY = (i - 1) * maxHeight;

                if (pages == i)
                {
                    newImgHeight = height - newImgY;
                }

                System.Drawing.Rectangle cropArea = new System.Drawing.Rectangle(0, newImgY, width, newImgHeight);
                //进行裁剪
                Bitmap bmpCrop = bitmap.Clone(cropArea, bitmap.PixelFormat);
                result.Add(bmpCrop);
            }

            return result;
        }

        /// <summary>
        /// 多张图片合成一张
        /// </summary>
        /// <param name="Bitmaps"></param>
        /// <returns></returns>
        private Bitmap SynthesisImg(IEnumerable<Bitmap> Bitmaps)
        {
            int width = Bitmaps.Max(p => p.Width);//设定宽度
            int height = Bitmaps.Sum(p => p.Height);//设定高度  

            Bitmap mybmp = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(mybmp))
            {
                int bitMapY = 0;
                foreach (var item in Bitmaps)
                {
                    gr.DrawImage(item, new System.Drawing.Rectangle(0, bitMapY, item.Width, item.Height));
                    bitMapY += item.Height;
                }
            }

            return mybmp;
        }


        /// <summary>  
        /// 修改注册表信息来兼容当前程序  
        ///   
        /// </summary>  
        static void SetWebBrowserFeatures(int ieVersion)
        {
            // don't change the registry if running in-proc inside Visual Studio  
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                return;
            //获取程序及名称  
            var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            //得到浏览器的模式的值  
            UInt32 ieMode = GeoEmulationModee(ieVersion);
            var featureControlRegKey = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\";
            //设置浏览器对应用程序（appName）以什么模式（ieMode）运行  
            Microsoft.Win32.Registry.SetValue(featureControlRegKey + "FEATURE_BROWSER_EMULATION",
                appName, ieMode, Microsoft.Win32.RegistryValueKind.DWord);
            // enable the features which are "On" for the full Internet Explorer browser  
            //不晓得设置有什么用  
            Microsoft.Win32.Registry.SetValue(featureControlRegKey + "FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION",
                appName, 1, Microsoft.Win32.RegistryValueKind.DWord);


            //Registry.SetValue(featureControlRegKey + "FEATURE_AJAX_CONNECTIONEVENTS",  
            //    appName, 1, RegistryValueKind.DWord);  


            //Registry.SetValue(featureControlRegKey + "FEATURE_GPU_RENDERING",  
            //    appName, 1, RegistryValueKind.DWord);  


            //Registry.SetValue(featureControlRegKey + "FEATURE_WEBOC_DOCUMENT_ZOOM",  
            //    appName, 1, RegistryValueKind.DWord);  


            //Registry.SetValue(featureControlRegKey + "FEATURE_NINPUT_LEGACYMODE",  
            //    appName, 0, RegistryValueKind.DWord);  
        }
        /// <summary>  
        /// 获取浏览器的版本  
        /// </summary>  
        /// <returns></returns>  
        static int GetBrowserVersion()
        {
            int browserVersion = 0;
            using (var ieKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }
            //如果小于7  
            if (browserVersion < 7)
            {
                throw new ApplicationException("不支持的浏览器版本!");
            }
            return browserVersion;
        }
        /// <summary>  
        /// 通过版本得到浏览器模式的值  
        /// </summary>  
        /// <param name="browserVersion"></param>  
        /// <returns></returns>  
        static UInt32 GeoEmulationModee(int browserVersion)
        {
            UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode.   
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode.   
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode.   
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode.                      
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10.  
                    break;
                case 11:
                    mode = 11000; // Internet Explorer 11  
                    break;
            }
            return mode;
        }

    }
}
