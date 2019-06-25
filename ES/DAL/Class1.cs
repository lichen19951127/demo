using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    using Elasticsearch.Net;
    using Nest;
    using Entity;
    public class Class1
    {
        public void ES()
        {
            var node = new Uri("http://myserver:9200");
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);


            //var nodes = new Uri[]
            //{
            //    new Uri("http://myserver1:9200"),
            //     new Uri("http://myserver2:9200"),
            //     new Uri("http://myserver3:9200")
            //};

            //var pool = new StaticConnectionPool(nodes);
            //var settings = new ConnectionSettings(pool);
            //var client = new ElasticClient(settings);

            //指定默认索引
            //var settings = new ConnectionSettings().DefaultIndex("defaultindex");
            // var settings = new ConnectionSettings().MapDefaultTypeIndices(m => m.Add(typeof(Project), "projects"));

            //请求单一节点
            var singleString = Nest.Indices.Index("db_studnet");
             var singleTyped = Nest.Indices.Index<Student>();
            
  ISearchRequest singleStringRequest = new SearchDescriptor<Student>().Index(singleString);
             ISearchRequest singleTypedRequest = new SearchDescriptor<Student>().Index(singleTyped);
  //请求多个节点
  var manyStrings = Nest.Indices.Index("db_studnet", "db_other_student");
             var manyTypes = Nest.Indices.Index<Student>().And<OtherStudent>();
            
 ISearchRequest manyStringRequest = new SearchDescriptor<Student>().Index(manyStrings);
             ISearchRequest manyTypedRequest = new SearchDescriptor<Student>().Index(manyTypes);
            
 //请求所有节点
var indicesAll = Nest.Indices.All;
             var allIndices = Nest.Indices.AllIndices;
            
 ISearchRequest indicesAllRequest = new SearchDescriptor<Student>().Index(indicesAll);
             ISearchRequest allIndicesRequest = new SearchDescriptor<Student>().Index(allIndices);


        }


    }

    [ElasticsearchType(Name = "student")]
    public class Student
    {
        [Nest.String(Index = FieldIndexOption.NotAnalyzed)]
        public string Id { get; set; }

        [Nest.String(Analyzer = "standard")]
        public string Name { get; set; }

        [Nest.String(Analyzer = "standard")]
        public string Description { get; set; }

        public DateTime DateTime { get; set; }
    }

}
