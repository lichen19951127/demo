using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Library.Helper;
using ZFS.Model;

namespace ZFS.ServerLibrary
{
    public partial class BaseService : IBaseService
    {
        /// <summary>
        /// 获取字典
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> GetDicTypes()
        {
            var dicList = await Factory.GetDictionaryTypeManager().GetDictionaryTypes();
            byte[] bytes = ZipTools.CompressionObject(dicList);
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
        public async Task<byte[]> GetPagingModelsByDicType(int pageIndex, int pageSize,
            byte[] search,
            bool Asc = false)
        {
            var DicSearch = ZipTools.DecompressionObject(search) as tb_DictionaryType;
            var DicList = await Factory.GetDictionaryTypeManager().GetPagingModels(pageIndex, pageSize, DicSearch, Asc);
            byte[] bytes = ZipTools.CompressionObject(DicList);
            return bytes;
        }

        /// <summary>
        /// 删除字典
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> DeleteEntityByDicType(byte[] entity)
        {
            var dic = ZipTools.DecompressionObject(entity) as tb_DictionaryType;
            var result = await Factory.GetDictionaryTypeManager().DeleteEntity(dic);
            byte[] bytes = ZipTools.CompressionObject(result);
            return bytes;
        }

        /// <summary>
        /// 更新字典
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> UpdateEntityByDicType(byte[] entity)
        {
            var dic = ZipTools.DecompressionObject(entity) as tb_DictionaryType;
            var result = await Factory.GetDictionaryTypeManager().UpdateEntity(dic);
            return ZipTools.CompressionObject(result);
        }

        /// <summary>
        /// 新增字典
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> AddEntityByDicType(byte[] entity)
        {
            var dic = ZipTools.DecompressionObject(entity) as tb_DictionaryType;
            var NewDic = await Factory.GetDictionaryTypeManager().UpdateEntity(dic);
            byte[] bytes = ZipTools.CompressionObject(NewDic);
            return bytes;
        }

        /// <summary>
        /// 检查字典是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<byte[]> ExistEntityByDicType(byte[] entity)
        {
            var dic = ZipTools.DecompressionObject(entity) as tb_DictionaryType;
            var result = await Factory.GetDictionaryTypeManager().ExistEntity(dic);
            byte[] bytes = ZipTools.CompressionObject(result);
            return bytes;
        }
    }
}
