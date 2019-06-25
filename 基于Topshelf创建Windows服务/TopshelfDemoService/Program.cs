using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopshelfDemoService
{
    class Program
    {
        static void Main(string[] args)
        {
            //开启Topshelf服务
            MyServiceConfigure.Configure();

            //安装成电脑服务
            //管理员打开cmd 进入Debug文件夹
            //TopshelfDemoService.exe install
            //TopshelfDemoService.exe uninstall
        }
    }
}
