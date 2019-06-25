using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logs
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Configuration.Json;
    /// <summary>
    /// 读取appsetting.json
    /// </summary>
    public class AppConfigurtaionServices
    {
        public static IConfiguration Configuration { get; set; }
        static AppConfigurtaionServices()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }

        ////调用
        // AppConfigurtaionServices.Configuration.GetConnectionString("LogsPath");
        ////读取一级
        // AppConfigurtaionServices.Configuration["Path"];
        ////读取二级
        // AppConfigurtaionServices.Configuration["Path:LogsPath"];

        //注意，如果AppConfigurtaionServices类中抛出FileNotFoundException异常，说明目录下未找到appsettings.json文件，这时请在项目appsettings.json文件上右键——属性——将“复制到输出目录”项的值改为“如果较新则复制”即可。


    }
}
