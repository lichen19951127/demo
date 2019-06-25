using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFSData.InterFace;
using ZFSData.InterFace.User;
using ZFSInterface.User;

namespace ZFSData.Manager
{
    /// <summary>
    /// EF管理器
    /// </summary>
    class EntityFrameworkManager : IDataManager
    {
        /// <summary>
        /// 用户操作接口
        /// </summary>
        /// <returns></returns>
        public IUser GetUserManager()
        {
            return new UserManager();
        }

        /// <summary>
        /// 用户组操作接口
        /// </summary>
        /// <returns></returns>
        public IGroup GetGroupManager()
        {
            return new GroupManager();
        }

        /// <summary>
        /// 菜单操作接口
        /// </summary>
        /// <returns></returns>
        public IMenu GetMenuManager()
        {
            return new MenuManager();
        }

        /// <summary>
        /// 字典接口
        /// </summary>
        /// <returns></returns>
        public IDictionary GetDictionaryManager()
        {
            return new DictionaryManager();
        }

        /// <summary>
        /// 代码操作接口
        /// </summary>
        /// <returns></returns>
        public IGenerator GetGeneratorManager()
        {
            return new GeneratorManager();
        }
        
        /// <summary>
        /// 字典类型接口
        /// </summary>
        /// <returns></returns>
        public IDictionaryType GetDictionaryTypeManager()
        {
            return new DictionaryTypeManager();
        }
    }
}
