using System;
using System.Configuration;
using Memcached.ClientLibrary;

namespace Web.Net
{
    /// <summary>
    /// Copyright (C) 2015-2019 LiChen
    /// Memcache操作类
    /// QQ 594281739
    /// Email 594281739@qq.com
    /// </summary>
    public class MemcacheHelper
    {
        /// <summary>
        /// 字段_instance,存放注册的缓存信息
        /// </summary>
        private static MemcacheHelper _instance;

        /// <summary>
        /// 缓存客户端
        /// </summary>
        private readonly MemcachedClient _client;

        /// <summary>
        /// 受保护类型的缓存对象，初始化一个新的缓存对象
        /// </summary>
        protected MemcacheHelper()
        {
            //读取app.Config中需要缓存的服务器地址信息，可以传递多个地址，使用","分隔
            string[] serverList = ConfigurationManager.AppSettings["Memcached.ServerList"].Split(',');
            try
            {
                // Memcached服务器列表
                // 如果有多台服务器，则以逗号分隔，例如："192.168.80.10:11211","192.168.80.11:11211"
                //string[] serverList = { "127.0.0.1:11211" };
                // 初始化SocketIO池
                string poolName = "MyPool";
                SockIOPool sockIOPool = SockIOPool.GetInstance(poolName);
                // 添加服务器列表
                sockIOPool.SetServers(serverList);
                // 设置连接池初始数目
                sockIOPool.InitConnections = 3;
                // 设置连接池最小连接数目
                sockIOPool.MinConnections = 3;
                // 设置连接池最大连接数目
                sockIOPool.MaxConnections = 5;
                // 设置连接的套接字超时时间（单位：毫秒）
                sockIOPool.SocketConnectTimeout = 1000;
                // 设置套接字超时时间（单位：毫秒）
                sockIOPool.SocketTimeout = 3000;
                // 设置维护线程运行的睡眠时间：如果设置为0，那么维护线程将不会启动
                sockIOPool.MaintenanceSleep = 30;
                // 设置SockIO池的故障标志
                sockIOPool.Failover = true;
                // 是否用nagle算法启动
                sockIOPool.Nagle = false;
                // 正式初始化容器
                sockIOPool.Initialize();

                // 获取Memcached客户端实例
                _client = new MemcachedClient();
                // 指定客户端访问的SockIO池
                _client.PoolName = poolName;
                // 是否启用压缩数据：如果启用了压缩，数据压缩长于门槛的数据将被储存在压缩的形式
                _client.EnableCompression = false;
            }
            catch (Exception ex)
            {
                //错误信息写入事务日志
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取缓存的实例对象，方法调用的时候使用
        /// </summary>
        /// <returns></returns>
        public static MemcacheHelper GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// 添加缓存信息(如果存在缓存信息则直接重写设置，否则添加)
        /// 使用：MemcacheHelper.GetInstance().Add(key,value)
        /// </summary>
        /// <param name="key">需要缓存的键</param>
        /// <param name="value">需要缓存的值</param>
        public void Add(string key, object value)
        {
            if (_client.KeyExists(key))
            {
                _client.Set(key, value);
            }
            _client.Add(key, value);
        }

        /// <summary>
        /// 添加缓存信息
        /// 使用：MemcacheHelper.GetInstance().Add(key,value,Datetime.Now())
        /// </summary>
        /// <param name="key">需要缓存的键</param>
        /// <param name="value">需要缓存的值</param>
        /// <param name="expiredDateTime">设置的缓存的过时时间</param>
        public void Add(string key, object value, DateTime expiredDateTime)
        {
            _client.Add(key, value, expiredDateTime);
        }

        /// <summary>
        /// 修改缓存的值
        /// 使用：MemcacheHelper.GetInstance().Update(key,value)
        /// </summary>
        /// <param name="key">需要修改的键</param>
        /// <param name="value">需要修改的值</param>
        public void Update(string key, object value)
        {
            _client.Replace(key, value);
        }

        /// <summary>
        /// 修改缓存的值
        /// 使用：MemcacheHelper.GetInstance().Update(key,value,Datetime.Now())
        /// </summary>
        /// <param name="key">需要修改的键</param>
        /// <param name="value">需要修改的值</param>
        /// <param name="expiredDateTime">设置的缓存的过时时间</param>
        public void Update(string key, object value, DateTime expiredDateTime)
        {
            _client.Replace(key, value, expiredDateTime);
        }

        /// <summary>
        /// 设置缓存
        /// 使用：MemcacheHelper.GetInstance().Set(key,value)
        /// </summary>
        /// <param name="key">设置缓存的键</param>
        /// <param name="value">设置缓存的值</param>
        public void Set(string key, object value)
        {
            _client.Set(key, value);
        }

        /// <summary>
        /// 设置缓存，并修改过期时间
        /// 使用：MemcacheHelper.GetInstance().Set(key,value,Datetime.Now())
        /// </summary>
        /// <param name="key">设置缓存的键</param>
        /// <param name="value">设置缓存的值</param>
        /// <param name="expiredTime">设置缓存过期的时间</param>
        public void Set(string key, object value, DateTime expiredTime)
        {
            _client.Set(key, value, expiredTime);
        }

        /// <summary>
        /// 删除缓存
        /// 使用：MemcacheHelper.GetInstance().Delete(key)
        /// </summary>
        /// <param name="key">需要删除的缓存的键</param>
        public void Delete(string key)
        {
            _client.Delete(key);
        }

        /// <summary>
        /// 获取缓存的值
        /// 使用：MemcacheHelper.GetInstance().Get(key)
        /// </summary>
        /// <param name="key">传递缓存中的键</param>
        /// <returns>返回缓存在缓存中的信息</returns>
        public object Get(string key)
        {
            return _client.Get(key);
        }

        /// <summary>
        /// 缓存是否存在
        /// 使用：MemcacheHelper.GetInstance().KeyExists(key)
        /// </summary>
        /// <param name="key">传递缓存中的键</param>
        /// <returns>如果为true，则表示存在此缓存，否则比表示不存在</returns>
        public bool KeyExists(string key)
        {
            return _client.KeyExists(key);
        }

        /// <summary>
        /// 注册Memcache缓存(在Global.asax的Application_Start方法中注册)
        /// 使用：MemcacheHelper.RegisterMemcache();
        /// </summary>
        public static void RegisterMemcache()
        {
            if (_instance == null)
            {
                _instance = new MemcacheHelper();
            }
        }
    }
}