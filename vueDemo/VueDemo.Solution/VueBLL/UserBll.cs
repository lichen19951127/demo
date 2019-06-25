using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueBLL
{
    using MODEL;
    using VueDAL;
    public class UserBll
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        public int AddUser(TUser user)
        {
            return new UserDAL().AddUser(user);

        }
        /// <summary>
        /// 显示用户
        /// </summary>
        /// <returns></returns>
        public string GetUser()
        {
            return new UserDAL().GetUser();

        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public int DeleteUser(int id)
        {
            return new UserDAL().DeleteUser(id);

        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        public int UpdateUser(TUser user)
        {
            return new UserDAL().UpdateUser(user);

        }
    }
}
