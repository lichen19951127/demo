using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.ServerBusiness;
using ZFSData.InterFace;
using ZFSData.InterFace.User;
using ZFSData.Manager;
using ZFSInterface.User;

namespace ZFSBridge
{
    /// <summary>
    /// 数据连接方式
    /// </summary>
    public enum BridgeType
    {
        ADO,
        Http,
        WebApi,
        Wcf,
    }

    /// <summary>
    /// 数据桥接工厂
    /// </summary>
    public class BridgeFactory
    {
        /// <summary>
        /// 连接模式
        /// </summary>
        private static BridgeType bridgeType = BridgeType.ADO;

        /// <summary>
        /// 获取用户桥接接口
        /// </summary>
        /// <returns></returns>
        public static IUser GetUserBridge()
        {
            if (bridgeType == BridgeType.ADO)
            {
                return new FactoryManager().GetUserManager();
            }
            else if(bridgeType==BridgeType.Wcf)
            {
                return WCF_UserManager.GetManager();
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取用户组桥接接口
        /// </summary>
        /// <returns></returns>
        public static IGroup GetGroupBridge()
        {
            if (bridgeType == BridgeType.ADO)
            {
                return new FactoryManager().GetGroupManager();
            }
            else if (bridgeType == BridgeType.Wcf)
            {
                return WCF_GroupManager.GetManager();
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取菜单桥接接口
        /// </summary>
        /// <returns></returns>
        public static IMenu GetMenuBridge()
        {
            if (bridgeType == BridgeType.ADO)
            {
                return new FactoryManager().GetMenuManager();
            }
            else if (bridgeType == BridgeType.Wcf)
            {
                return WCF_MenuManager.GetManager();
            }
            throw new NotImplementedException();
        }


        /// <summary>
        /// 获取字典桥接接口
        /// </summary>
        /// <returns></returns>
        public static IDictionary GetDictionaryBridge()
        {
            if (bridgeType == BridgeType.ADO)
            {
                return new FactoryManager().GetDictionaryManager();
            }
            else if (bridgeType == BridgeType.Wcf)
            {
                return WCF_DictionaryManager.GetManager();
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取字典类型桥接接口
        /// </summary>
        /// <returns></returns>
        public static IDictionaryType GetDictionaryTypeBridge()
        {
            if (bridgeType == BridgeType.ADO)
            {
                return new FactoryManager().GetDictionaryTypeManager();
            }
            else if (bridgeType == BridgeType.Wcf)
            {
                return WCF_DictionTypeManager.GetManager();
            }
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// 获取代码生成接口
        /// </summary>
        /// <returns></returns>
        public static IGenerator GetGeneratorBridge()
        {
            if (bridgeType == BridgeType.ADO)
            {
                return new FactoryManager().GetGeneratorManager();
            }
            else if (bridgeType == BridgeType.Wcf)
            {
                return WCF_GeneratorManager.GetManager();
            }
            throw new NotImplementedException();
        }
        
    }
}
