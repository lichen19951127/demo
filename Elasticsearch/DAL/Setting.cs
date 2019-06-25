using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public  class Setting
    {
        public static Uri Node
        {
            get
            {
                return new Uri("http://localhost:9200");
            }
        }
        //连接配置
        public static ConnectionSettings ConnectionSettings
        {
            get
            {
                return new ConnectionSettings(Node, defaultIndex: "es-index-app");
            }
        }
    }
}
