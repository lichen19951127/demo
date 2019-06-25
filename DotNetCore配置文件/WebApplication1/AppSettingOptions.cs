using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    /// <summary>
    /// appsettings.json的配置类
    /// </summary>
    public class AppSettingOptions
    {
        public DefaultConnec ConnectionStrings { get; set; }
        public string AllowedHosts { get; set; }
    }

    public class DefaultConnec
    {
        public string DefaultConnection { get; set; }
    }
}
