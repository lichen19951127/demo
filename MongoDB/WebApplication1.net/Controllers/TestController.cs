using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.net.Controllers
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            //建立连接
            var client = new MongoClient();
            //建立数据库
            var database = client.GetDatabase("TestDb");
            //建立collection
            var collection = database.GetCollection<BsonDocument>("foo");

            var document = new BsonDocument
            {
                {"name","MongoDB"},
                {"type","Database"},
                {"count",1},
                {"info",new BsonDocument{{"x",203},{"y",102}}}
            };
            //插入数据
            collection.InsertOne(document);

            var count = collection.Count(document);
            Console.WriteLine(count);

            //查询数据
            var document1 = collection.Find(document);
            Console.WriteLine(document1.ToString());

            //更新数据
            var filter = Builders<BsonDocument>.Filter.Eq("name", "MongoDB");
            var update = Builders<BsonDocument>.Update.Set("name", "Ghazi");

            collection.UpdateMany(filter, update);

            //删除数据
            var filter1 = Builders<BsonDocument>.Filter.Eq("count", 101);

            collection.DeleteMany(filter1);

            BsonDocument document2 = new BsonDocument();
            document2.Add("name", "MongoDB");
            document2.Add("type", "Database");
            document2.Add("count", "1");

            collection.InsertOne(document2);
            return View();
        }

        MongoDbHelper<Users> mg = new MongoDbHelper<Users>();


        public ActionResult Test()
        {
            Users user = new Users();
            user.UsersId = 1;
            user.Name = "张三";
            //新增
           var a= mg.Insert(user);
            //查询
          var b=  mg.QueryAll();
           //var c= mg.QueryOne(1.ToString());
            //修改
            user.Name = "张三123";
            mg.Update(user);

            var b2 = mg.QueryAll();


            //删除
            mg.Delete(user);

            var b3 = mg.QueryAll();
            return View();
        }


    }
}