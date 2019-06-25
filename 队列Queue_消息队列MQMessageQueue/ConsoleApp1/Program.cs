using System;
using System.Collections.Generic;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建队列
            Queue<UserInfo> queue = new Queue<UserInfo>();

            //获取用户下单列表
            List<UserInfo> userList = GetUserList();

            //使用Enqueue()方法将用户下单信息加入到队列中（入列）
            foreach (var user in userList)
            {
                queue.Enqueue(user);
            }

        //常用的属性 & 描述

        //Count：Count属性返回队列中元素个数。
        //Enqueue：Enqueue()方法在队列一端添加一个元素。
        //Dequeue：Dequeue()方法在队列的头部读取和删除元素。如果在调用Dequeue()方法时，队列中不再有元素，就抛出一个InvalidOperationException类型的异常。
        //Peek：Peek()方法从队列的头部读取一个元素，但不删除它。
        //TrimExcess：TrimExcess()方法重新设置队列的容量。Dequeue()方法从队列中删除元素，但它不会重新设置队列的容量。要从队列的头部去除空元素，应使用TrimExcess()方法。
        //Clear：Clear()方法从队列中移除所有的元素。
        //ToArray：ToArray()复制队列到一个新的数组中。


            //使用Count属性获取队列中元素个数
            int queueCount = queue.Count;
            Console.WriteLine(string.Format("队列中有{0}个用户下单信息。", queueCount));  //输出

            //使用Dequeue()方法从队列的头部读取和删除元素（出列）
            //队列先进先出 
            for (int i = 0; i < queueCount; i++)
            {
                UserInfo user = queue.Dequeue();
                Console.WriteLine(string.Format("\n单号：{0}；用户名称：{1}；手机号：{2}；收货地址：{3}；商品名称：{4}；价格：{5}",
                    user.ID, user.Name, user.Phone, user.Address, user.Commodity, user.Price));
            }

            //使用Count属性获取队列中元素的格式
            queueCount = queue.Count;
            Console.WriteLine(string.Format("\n队列中有{0}个用户下单信息。", queueCount));  //输出
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public static List<UserInfo> GetUserList()
        {
            List<UserInfo> userList = new List<UserInfo>();
            userList.Add(new UserInfo("201906031010", "王母", "1821234****", "昆仑山玉虚宫", "9万年蟠桃", 136.00));
            userList.Add(new UserInfo("201906031011", "喜洋洋", "1821235****", "青青草原羊村", "狼堡牌无毒除虫剂", 198.00));
            userList.Add(new UserInfo("201906031012", "光头强", "1821236****", "狗熊岭光头强家", "捕兽夹", 346.00));
            userList.Add(new UserInfo("201906031013", "孙悟空", "1821237****", "花果山", "去虱粉", 245.00));
            return userList;
        }
    }
    public class UserInfo
    {
        public UserInfo(string id, string name, string phone, string address, string commodity, double price)
        {
            this.ID = id;
            this.Name = name;
            this.Phone = phone;
            this.Address = address;
            this.Commodity = commodity;
            this.Price = price;

        }
        public string ID { get; set; }   //单号
        public string Name { get; set; }  //姓名
        public string Phone { get; set; }  //手机号
        public string Address { get; set; }  //收货地址
        public string Commodity { get; set; }  //商品名称
        public double Price { get; set; }  //价格
    }
}
