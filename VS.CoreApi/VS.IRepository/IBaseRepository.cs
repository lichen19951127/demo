using System;
using System.Collections.Generic;
using System.Text;

namespace VS.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity QueryById(object id, bool isCache = false);

        /// <summary>
        /// 获取全部实体
        /// </summary>
        /// <returns></returns>
        List<TEntity> QueryList();

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int InsertEntity(TEntity obj);

        /// <summary>
        /// 批量插入实体
        /// </summary>
        /// <param name="list"></param>
        bool InsertEntityList(List<TEntity> list);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool UpdateEntity(TEntity obj);

        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        bool DeleteById(object id);
    }
}
