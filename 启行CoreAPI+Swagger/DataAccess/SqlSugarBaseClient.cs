using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class SqlSugarBaseClient
    {
        public static string DB_ConnectionString { get; set; }

        public static SqlSugarClient DB
        {
            get => new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = DB_ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,//是否自动关闭连接
                InitKeyType = InitKeyType.SystemTable,//根据实体模型初始化表
                IsShardSameThread = true//是线程共享
            }
            );
        }
    }
}
