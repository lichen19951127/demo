using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace WebApplication1.net
{
    public class Db
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();

        private static readonly string dbName = ConfigurationManager.AppSettings["dbName"].ToString();

        private static IMongoDatabase db = null;

        private static readonly object lockHelper = new object();

        private Db() { }

        public static IMongoDatabase GetDb()
        {
            if (db == null)
            {
                lock (lockHelper)
                {
                    if (db == null)
                    {
                        var client = new MongoClient(connStr);
                        db = client.GetDatabase(dbName);
                    }
                }
            }
            return db;
        }
    }

    public class MongoDbHelper<T> where T : Users
    {
        private IMongoDatabase db = null;

        private IMongoCollection<T> collection = null;

        public MongoDbHelper()
        {
            this.db = Db.GetDb();
            collection = db.GetCollection<T>(typeof(T).Name);
        }

        public T Insert(T entity)
        {
            var flag = ObjectId.GenerateNewId();
            entity.GetType().GetProperty("Id").SetValue(entity, flag);
            entity.State = "y";
            entity.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            entity.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            collection.InsertOneAsync(entity);
            return entity;
        }

        public void Modify(string id, string field, string value)
        {
            var filter = Builders<T>.Filter.Eq("Id", ObjectId.Parse(id));
            var updated = Builders<T>.Update.Set(field, value);
            UpdateResult result = collection.UpdateOneAsync(filter, updated).Result;
        }

        public void Update(T entity)
        {
            var old = collection.Find(e => e.Id.Equals(entity.Id)).ToList().FirstOrDefault();

            foreach (var prop in entity.GetType().GetProperties())
            {
                var newValue = prop.GetValue(entity);
                var oldValue = old.GetType().GetProperty(prop.Name).GetValue(old);
                if (newValue != null)
                {
                    if (!newValue.ToString().Equals(oldValue.ToString()))
                    {
                        old.GetType().GetProperty(prop.Name).SetValue(old, newValue.ToString());
                    }
                }
            }
            old.State = "y";
            old.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var filter = Builders<T>.Filter.Eq("Id", entity.Id);
            ReplaceOneResult result = collection.ReplaceOneAsync(filter, old).Result;
        }

        public void Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", entity.Id);
            collection.DeleteOneAsync(filter);
        }

        public T QueryOne(string id)
        {
            return collection.Find(a => a.Id == ObjectId.Parse(id)).ToList().FirstOrDefault();
        }

        public List<T> QueryAll()
        {
            return collection.Find(a => a.State.Equals("y")).ToList();
        }
    }
}