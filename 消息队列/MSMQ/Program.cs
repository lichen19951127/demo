using Experimental.System.Messaging;
using System;

namespace MSMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = null;
            //判断指定的路径是否存在“消息队列”队列，如果存在直接初始化，并设置好说明
            //否则在指定的路径中创建“消息队列”
            if (MessageQueue.Exists(@".\Private$\MyQueues"))
            {
                messageQueue = new MessageQueue(@".\Private$\MyQueues");
                messageQueue.Label = "Testing Queue";
            }
            else
            {
                messageQueue = MessageQueue.Create(@".\Private$\MyQueues");
                messageQueue.Label = "New Create Queue";
            }

            //发送对象到消息队列中，并设置好标签
            messageQueue.Send("First ever Message is sent to MSMQ", "Title");
            //设置消息类型
            messageQueue.Formatter = new XmlMessageFormatter(new string[] { "System.String" });

            foreach (Message msg in messageQueue)
            {
                string readMessage = msg.Body.ToString();
                Console.WriteLine(readMessage);
            }
            messageQueue.Purge();

            Console.Read();
        }
    }
}
