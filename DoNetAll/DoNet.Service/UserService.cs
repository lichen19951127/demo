using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNet.Service
{
    using DoNet.Common;
    using DoNet.Entity;

    public static class UserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static Users Login(string name,string pwd)
        {
            var sql = string.Format("select * from Users where Name='{0}' and Pwd='{1}'",name,pwd);
            var result = DBHelper.ExecuteObject<Users>(sql);
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public static List<Users> Query()
        {
            var sql = string.Format("select * from Users");
            var result = DBHelper.ExecuteObjects<Users>(sql);
            return result;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public static int Add(Users model)
        {
            var sql = string.Format("insert into Users values('{0}','{1}','{2}','{3}','{4}','{5}')",model.Name,model.Pwd,model.Sex,model.Hobby,model.Address,model.Img);
            var result = DBHelper.ExecuteNonQuery(sql);
            return result;
        }
    }
}
