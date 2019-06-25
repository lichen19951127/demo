using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Library.Generator;
using ZFS.Library.Helper;

namespace ZFS.ServerLibrary
{
    partial class BaseService : IBaseService
    {
        /// <summary>
        /// 获取表OR视图
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> GetUvs()
        {
            var result = await Factory.GetGeneratorManager().GetUvs();
            byte[] bytes = ZipTools.CompressionObject(result);
            return bytes;
        }

        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public async Task<byte[]> GetTableStatus(string tableName, string nameSpace, string desc)
        {
            var result = await Factory.GetGeneratorManager().GetTableStructs(tableName, nameSpace, desc);
            byte[] bytes = ZipTools.CompressionObject(result);
            return bytes;
        }
    }
}
