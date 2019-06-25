using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

namespace Web2
{
    public class MyConnection : PersistentConnection
    {
        private static List<string> monitoringIdList = new List<string>();

        /// <summary>
        /// 连接成功后调用
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            bool IsMonitoring = (request.QueryString["Monitoring"] ?? "").ToString() == "Y";
            if (IsMonitoring)
            {
                if (!monitoringIdList.Contains(connectionId))
                {
                    monitoringIdList.Add(connectionId);
                }
                return Connection.Send(connectionId, "ready_"+connectionId);
            }
            else
            {
                if (monitoringIdList.Count > 0)
                {
                    Connection.Send(connectionId, "one_" + connectionId);
                    return Connection.Send(monitoringIdList, "in_" + connectionId);
                }
                else
                {
                    return Connection.Send(connectionId, "nobody");
                }
            }
        }

        /// <summary>
        /// 接收到请求的时候调用
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            if (monitoringIdList.Contains(connectionId))
            {
                return Connection.Send(data, "pass_"+ connectionId);
            }
            if (data != null)
            {
                var model = JsonConvert.DeserializeObject<TempData>(data);
                return Connection.Send(model.receiveId, model.msg);
            }
            return null;
        }
        /// <summary>
        /// 连接中断的时候调用
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            if (!monitoringIdList.Contains(connectionId))
            {
                return Connection.Send(monitoringIdList, "out_" + connectionId);
            }
            return null;
        }
        /// <summary>
        /// 连接超时重新连接的时候调用
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        protected override Task OnReconnected(IRequest request, string connectionId)
        {
            return base.OnReconnected(request, connectionId);
        }

    }

    public class TempData
    {
        /// <summary>
        /// 接收人的connectionId
        /// </summary>
        public string receiveId { get; set; }

        /// <summary>
        /// 发送内容
        /// </summary>
        public string msg { get; set; }
    }
}