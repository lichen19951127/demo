using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApplication1.NetCore.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()

        {
            MongodbHost host = new MongodbHost();
            host.Connection = "mongodb://127.0.0.1:27017";
            host.DataBase = "testdb11";
            host.Table = "PhoneEntity";

            PhoneEntity model = new PhoneEntity();
            model.Name = "张三";
            model.Price = 123;
            model.AddTime = DateTime.Now;
            model.UseAge = 20;
           var a=TMongodbHelper<PhoneEntity>.Add(host,model);

            var c = TMongodbHelper<PhoneEntity>.FindOne(host, model.Id.ToString());

            model.Name = "张三111";

            var b = TMongodbHelper<PhoneEntity>.Update(host, model, model.Id.ToString());


            var d = TMongodbHelper<PhoneEntity>.FindOne( host, model.Id.ToString());
            ////1.批量修改,修改的条件
            //var time = DateTime.Now;
            //var list = new List<FilterDefinition<PhoneEntity>>();
            //list.Add(Builders<PhoneEntity>.Filter.Lt("AddTime", time.AddDays(5)));
            //list.Add(Builders<PhoneEntity>.Filter.Gt("AddTime", time));
            //var filter = Builders<PhoneEntity>.Filter.And(list);

            ////2.要修改的字段内容
            //var dic = new Dictionary<string, string>();
            //dic.Add("UseAge", "168");
            //dic.Add("Name", "朝阳");
            ////3.批量修改
            //var kk = TMongodbHelper<PhoneEntity>.UpdateManay(host, dic, filter);

            ////根据条件查询集合
            //var time = DateTime.Now;
            //var list = new List<FilterDefinition<PhoneEntity>>();
            //list.Add(Builders<PhoneEntity>.Filter.Lt("AddTime", time.AddDays(20)));
            //list.Add(Builders<PhoneEntity>.Filter.Gt("AddTime", time));
            //var filter = Builders<PhoneEntity>.Filter.And(list);
            ////2.查询字段
            //var field = new[] { "Name", "Price", "AddTime" };
            ////3.排序字段
            //var sort = Builders<PhoneEntity>.Sort.Descending("AddTime");
            //var res = TMongodbHelper<PhoneEntity>.FindList(host, filter, field, sort);


            ////分页查询，查询条件
            //var time = DateTime.Now;
            //var list = new List<FilterDefinition<PhoneEntity>>();
            //list.Add(Builders<PhoneEntity>.Filter.Lt("AddTime", time.AddDays(400)));
            //list.Add(Builders<PhoneEntity>.Filter.Gt("AddTime", time));
            //var filter = Builders<PhoneEntity>.Filter.And(list);
            //long count = 0;
            ////排序条件
            //var sort = Builders<PhoneEntity>.Sort.Descending("AddTime");
            //var res = TMongodbHelper<PhoneEntity>.FindListByPage(host, filter, 2, 10, out count, null, sort);



            return View();
        }
    }
    public class PhoneEntity {

        public PhoneEntity()
        {
            Id = ObjectId.GenerateNewId();
        }
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime AddTime { get; set; }
        public int UseAge { get; set; }
    }
}