using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using VS.Common;

namespace VS.Repository
{
    public class BaseRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 连接对象
        /// </summary>
        protected SqlSugarClient Db { get; set; }

        /// <summary>
        /// 实体连接对象
        /// </summary>
        protected SimpleClient<TEntity> DbEntity { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected BaseRepository()
        {
            DbContext.Init(AppsettingsHelper.GetConfigString("DataBase", "ConnectionString"));
            Db = DbContext.GetContext().Db;
            DbEntity = new SimpleClient<TEntity>(Db);
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity QueryById(object id, bool isCache = false)
        {
            return Db.Queryable<TEntity>().WithCacheIF(isCache).InSingle(id);
        }

        /// <summary>
        /// 获取全部实体
        /// </summary>
        /// <returns></returns>
        public List<TEntity> QueryList()
        {
            return Db.Queryable<TEntity>().ToList();
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertEntity(TEntity obj)
        {
            var id = Db.Insertable<TEntity>(obj).ExecuteReturnBigIdentity();
            return (int)id;
        }

        /// <summary>
        /// 批量插入实体
        /// </summary>
        /// <param name="list"></param>
        public bool InsertEntityList(List<TEntity> list)
        {
            return Db.Insertable<TEntity>(list).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool UpdateEntity(TEntity obj)
        {
            return Db.Updateable(obj).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public bool DeleteById(object id)
        {
            return Db.Deleteable<TEntity>(id).ExecuteCommand()>0;
        }

    }
}
