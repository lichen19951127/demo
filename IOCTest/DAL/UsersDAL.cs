using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    using Entity;
    using IDAL;
    using System.Data;
    using System.Data.SqlClient;
    using Newtonsoft.Json;
    using System.Configuration;
    public class UsersDAL : IUsers_DAL
    {
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int Add(Users u)
        {
            var sql =string.Format("insert into Users values('{0}')",u.Name);
            var result=DBHelper.ExecuteNonQuery(sql);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Delete(string ids)
        {
            var sql ="delete from Users where Id in (" + ids + ")";
            var result = DBHelper.ExecuteNonQuery(sql);
            return result;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<Users> Query()
        {
            var sql = "select * from Users";
            var dt= DBHelper.GetDataTable(sql);
            var json=JsonConvert.SerializeObject(dt);
            var list=JsonConvert.DeserializeObject<List<Users>>(json);
            return list;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int Update(Users u)
        { 
            var sql = string.Format("update Users set Name='{0}' where Id='{1}' ",u.Name,u.Id);
            var result = DBHelper.ExecuteNonQuery(sql);
            return result;
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Users QueryById(int id)
        {
            var sql = "select * from Users where Id="+id;
            var dt = DBHelper.GetDataTable(sql);
            var json = JsonConvert.SerializeObject(dt);
            var list = JsonConvert.DeserializeObject<Users>(json);
            return list;
        }

        
    }
}
