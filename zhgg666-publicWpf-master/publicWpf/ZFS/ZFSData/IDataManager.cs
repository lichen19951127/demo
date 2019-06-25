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
    /// EF接口管理
    /// </summary>
    interface IDataManager
    {
        /// <summary>
        /// 用户管理操作接口
        /// </summary>
        /// <returns></returns>
        IUser GetUserManager();

        /// <summary>
        /// 用户组管理操作接口
        /// </summary>
        /// <returns></returns>
        IGroup GetGroupManager();
        
        /// <summary>
        /// 菜单操作接口
        /// </summary>
        /// <returns></returns>
        IMenu GetMenuManager();

        /// <summary>
        /// 字典操作接口
        /// </summary>
        /// <returns></returns>
        IDictionary GetDictionaryManager();

        /// <summary>
        /// 代码生成接口
        /// </summary>
        /// <returns></returns>
        IGenerator GetGeneratorManager();

        /// <summary>
        /// 字典类型接口
        /// </summary>
        /// <returns></returns>
        IDictionaryType GetDictionaryTypeManager();
    }
}
