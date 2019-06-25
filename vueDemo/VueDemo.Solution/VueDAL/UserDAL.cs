using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueDAL
{
    using MODEL;
    using System.Data;
    using Newtonsoft.Json;
    public class UserDAL
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        public int AddUser(TUser user)
        {
            string sql = string.Format("insert into TUser(Name, Sex,Hobby, Role) values('{0}','{1}','{2}','{3}')", user.Name,user.Sex,user.Hobby,user.Role) ;
           return  DBHelper.ExecuteNonQuery(sql);
            
        }
        /// <summary>
        /// 显示用户
        /// </summary>
        /// <returns></returns>
        public string GetUser()
        {
            string sql = string.Format("select Id, Name, Sex, Hobby, Role from TUser");
            DataTable dt= DBHelper.GetDataTable(sql);
            var json = JsonConvert.SerializeObject(dt);
            return json;

        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public int DeleteUser(int id)
        {
            string sql = string.Format("delete from TUser where Id='{0}'", id);
            return DBHelper.ExecuteNonQuery(sql);

        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        public int UpdateUser(TUser user)
        {
            string sql = string.Format("update TUser set Name='{0}',Sex='{1}',Hobby='{2}',Role='{3}'where Id='{4}'", user.Name, user.Sex, user.Hobby, user.Role, user.Id);
            return DBHelper.ExecuteNonQuery(sql);

        }
    }
}
