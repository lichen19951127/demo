using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.DataAccess
{
    using SqlSugar;
   public class SqlSugarBaseClient
    {
        public static string DB_ConnectionString { get; set; }
        public static SqlSugarClient DB
        {
            get => new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = DB_ConnectionString,//必填, 数据库连接字符串
                DbType = DbType.SqlServer,         //必填, 数据库类型
                IsAutoCloseConnection = true,       //默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作 是否自动关闭连接
                InitKeyType = InitKeyType.SystemTable,    //默认SystemTable, 字段信息读取, 如：该属性是不是主键，是不是标识列等等信息 根据实体模型初始化表
                IsShardSameThread=true // 是线程共享
            });
        }
    }
}
