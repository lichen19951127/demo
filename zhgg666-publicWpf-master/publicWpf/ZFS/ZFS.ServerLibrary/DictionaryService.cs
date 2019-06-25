using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Library.Helper;
using ZFS.Model;
using ZFSData;

namespace ZFS.ServerLibrary
{
    public partial class BaseService : IBaseService
    {
        /// <summary>
        /// 获取字典
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> GetDictionarys()
        {
            var dicList = await Factory.GetDictionaryTypeManager().GetDictionaryTypes();
            byte[] bytes = ZipTools.CompressionObject(dicList);
            return bytes;
        }

        /// <summary>
        /// 查询字典数据
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<byte[]> GetModelsByDic(byte[] search)
        {
            var DicSearch = ZipTools.DecompressionObject(search) as tb_Dictionary;
            var DicList = await Factory.GetDictionaryManager().GetModels(DicSearch);
            byte[] bytes = ZipTools.CompressionObject(DicList);
            return bytes;
        }

        /// <summary>
        /// 查询字典数据-分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <param name="Asc"></param>
        /// <returns></returns>
        public async Task<byte[]> GetPagingModelsByDic(int pageIndex, int pageSize,
            byte[] search,
            bool Asc = false)
        {
            var DicSearch = ZipTools.DecompressionObject(search) as tb_Dictionary;
            var DicList = await Factory.GetDictionaryManager().GetPagingModels(pageIndex, pageSize, DicSearch, Asc);
            byte[] bytes = ZipTools.CompressionObject(DicList);
            return bytes;
        }

        /// <summary>
        /// 删除字典
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> DeleteEntityByDic(byte[] entity)
        {
            var dic = ZipTools.DecompressionObject(entity) as tb_Dictionary;
            var result = await Factory.GetDictionaryManager().DeleteEntity(dic);
            byte[] bytes = ZipTools.CompressionObject(result);
            return bytes;
        }

        /// <summary>
        /// 更新字典
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> UpdateEntityByDic(byte[] entity)
        {
            var dic = ZipTools.DecompressionObject(entity) as tb_Dictionary;
            var result = await Factory.GetDictionaryManager().UpdateEntity(dic);
            return ZipTools.CompressionObject(result);
        }

        /// <summary>
        /// 新增字典
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> AddEntityByDic(byte[] entity)
        {
            var dic = ZipTools.DecompressionObject(entity) as tb_Dictionary;
            var NewDic = await Factory.GetDictionaryManager().AddEntity(dic);
            byte[] bytes = ZipTools.CompressionObject(NewDic);
            return bytes;
        }

        /// <summary>
        /// 检查字典是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> ExistEntityByDic(byte[] entity)
        {
            var dic = ZipTools.DecompressionObject(entity) as tb_Dictionary;
            var result = await Factory.GetDictionaryManager().ExistEntity(dic);
            byte[] bytes = ZipTools.CompressionObject(result);
            return bytes;
        }
    }
}
