using System;
using System.Collections.Generic;
using System.Text;
using VS.IRepository;
using VS.IService;

namespace VS.Service
{
    public class BaseService<TEntity>  where TEntity : class, new()
    {
        protected IBaseRepository<TEntity> BaseDal { get; set; }
        public bool DeleteById(object id)
        {
            return BaseDal.DeleteById(id);
        }

        public int InsertEntity(TEntity obj)
        {
            return BaseDal.InsertEntity(obj);
        }

        public bool InsertEntityList(List<TEntity> list)
        {
            return BaseDal.InsertEntityList(list);
        }

        public TEntity QueryById(object id, bool isCache = false)
        {
            return BaseDal.QueryById(id,isCache);
        }

        public List<TEntity> QueryList()
        {
            return BaseDal.QueryList();
        }

        public bool UpdateEntity(TEntity obj)
        {
            return BaseDal.UpdateEntity(obj);
        }
    }
}
