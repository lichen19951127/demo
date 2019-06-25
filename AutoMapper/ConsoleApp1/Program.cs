using AutoMapper;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化
            Mapper.Initialize(map =>
            {
                map.CreateMap<User, Info>();
            });
            List<User> list = new List<User>() {
                new User(){ Id=1,Name="张三1"},
                new User(){ Id=2,Name="张三2"},
                new User(){ Id=3,Name="张三3"},
                new User(){ Id=4,Name="张三4"},
                new User(){ Id=5,Name="张三5"}
            };

            //方法1
            List<Info> infos = Mapper.Map<List<User>,List<Info>>(list);

            //方法2
            List<Info> infos2 = new List<Info>();
            Mapper.Map<List<User>, List<Info>>(list, infos2);


        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Info
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
