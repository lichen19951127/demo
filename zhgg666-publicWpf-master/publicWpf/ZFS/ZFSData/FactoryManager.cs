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
    /// 操作接口管理器
    /// </summary>
    public class FactoryManager
    {
        private IDataManager dataManager;

        public FactoryManager()
        {
            dataManager = new EntityFrameworkManager();
        }
        
        /// <summary>
        /// 获取用户操作接口
        /// </summary>
        /// <returns></returns>
        public IUser GetUserManager()
        {
            return dataManager.GetUserManager();
        }

        /// <summary>
        /// 获取用户组操作接口
        /// </summary>
        /// <returns></returns>
        public IGroup GetGroupManager()
        {
            return dataManager.GetGroupManager();
        }

        /// <summary>
        /// 获取菜单操作接口
        /// </summary>
        /// <returns></returns>
        public IMenu GetMenuManager()
        {
            return dataManager.GetMenuManager();
        }

        /// <summary>
        /// 获取字典操作接口
        /// </summary>
        /// <returns></returns>
        public IDictionary GetDictionaryManager()
        {
            return dataManager.GetDictionaryManager();
        }

        /// <summary>
        /// 获取字典类型操作接口
        /// </summary>
        /// <returns></returns>
        public IDictionaryType GetDictionaryTypeManager()
        {
            return dataManager.GetDictionaryTypeManager();
        }

        /// <summary>
        /// 获取代码生成接口
        /// </summary>
        /// <returns></returns>
        public IGenerator GetGeneratorManager()
        {
            return dataManager.GetGeneratorManager();
        }

    }
}
