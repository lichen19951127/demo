using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Configuration.Json;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System.IO;

    /// <summary>
    /// 读取appsetting.json
    /// </summary>
    public static class UtilConf
    {
        public static IConfiguration Configuration { get; set; }
        static UtilConf()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }
        public static string GetConnectionString(string conn)
        {
            //调用
            // UtilConf.Configuration.GetConnectionString("conn");
            //读取一级
            // UtilConf.Configuration["str"];
            //读取二级
            return UtilConf.Configuration["ConnectionStrings:"+ conn + ""];

            //注意，如果UtilConf类中抛出FileNotFoundException异常，说明目录下未找到appsettings.json文件，这时请在项目appsettings.json文件上右键——属性——将“复制到输出目录”项的值改为“如果较新则复制”即可。

        }
    }
}
