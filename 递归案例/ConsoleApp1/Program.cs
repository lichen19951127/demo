using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var data = GetData();

            //获取所有下级
            var query = GetSons(data, 1);

            //获取所有上级
            //var query = GetFatherList(data, 5);
            Console.WriteLine("Id\t 区划\t 父ID\t 层级\t");
            query.ToList().ForEach(q => Console.WriteLine("{0}\t {1}\t {2}\t {3}\t", q.Id, q.Name, q.Fid, q.Level));

            Console.ReadLine();
        }

        #region 测试数据
        public static IList<menu> GetData()
        {
            var list = new List<menu>();
            list.Add(new menu { Id = 1, Name = "广东省", Fid = 0, Level = 1 });
            list.Add(new menu { Id = 2, Name = "深圳市", Fid = 1, Level = 2 });
            list.Add(new menu { Id = 3, Name = "南山区", Fid = 2, Level = 3 });
            list.Add(new menu { Id = 4, Name = "福田区", Fid = 2, Level = 3 });
            list.Add(new menu { Id = 5, Name = "上梅林", Fid = 4, Level = 4 });
            list.Add(new menu { Id = 6, Name = "下梅林", Fid = 4, Level = 4 });
            list.Add(new menu { Id = 7, Name = "车公庙", Fid = 4, Level = 4 });
            list.Add(new menu { Id = 8, Name = "蛇口", Fid = 5, Level = 4 });
            list.Add(new menu { Id = 9, Name = "科技园", Fid = 5, Level = 4 });
            list.Add(new menu { Id = 10, Name = "湖南省", Fid = 0, Level = 1 });
            list.Add(new menu { Id = 11, Name = "长沙市", Fid = 10, Level = 2 });
            list.Add(new menu { Id = 12, Name = "芙蓉区", Fid = 11, Level = 3 });
            return list;
        }
        #endregion

        #region 获取所有下级
        public static IEnumerable<menu> GetSons(IList<menu> list, int Fid)
        {
            var query = list.Where(p => p.Id == Fid).ToList();
            var list2 = query.Concat(GetSonList(list, Fid));
            return list2;
        }

        public static IEnumerable<menu> GetSonList(IList<menu> list, int Fid)
        {
            var query = list.Where(p => p.Fid == Fid).ToList();
            return query.ToList().Concat(query.ToList().SelectMany(t => GetSonList(list, t.Id)));
        }
        #endregion

        #region 获取所有上级
        public static IEnumerable<menu> GetFatherList(IList<menu> list, int Id)
        {
            var query = list.Where(p => p.Id == Id).ToList();
            return query.ToList().Concat(query.ToList().SelectMany(t => GetFatherList(list, t.Fid)));
        }
        #endregion

        #region 实体类
        public class menu
        {
            public int Id { set; get; }
            public string Name { set; get; }
            public int Fid { set; get; }
            public int Level { set; get; }
        }
        #endregion
    }
}
