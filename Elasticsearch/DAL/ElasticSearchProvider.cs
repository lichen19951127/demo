using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    using Elasticsearch.Net;
    using Nest;

    public class ESProvider
    {
        public static ElasticClient client = new ElasticClient(Setting.ConnectionSettings);

        public bool Index(PersonDetail person)
        {
            var client = new ElasticClient(Setting.ConnectionSettings);
            try
            {
                //添加数据 
                //在调用下面的index方法的时候，如果没有指定使用哪个index，ElasticSearch会直接使用我们在setting中的defaultIndex，如果没有，则会自动创建
                var index = client.Index(person);
                return index.Created;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Excepton Message : " + ex.Message);
            }
            return false;
        }


        public List<PersonDetail> GetAll()
        {
            var searchResults = client.Search<PersonDetail>(s => s
                .From(0)
                .Size(10000)
                );
            return searchResults.Documents.ToList();
        }

        public List<PersonDetail> GetEntities(string keyword)
        {
            var client = new ElasticClient(Setting.ConnectionSettings);

            #region 全文搜索

            keyword = String.Format("*{0}*", keyword);
            //默认的Operator是Or,当keyword是类似于"One Two"之类的中间有空格的时候，会被当成两个关键词搜索，然后搜索结果进行or运算
            //所以我们需要根据需求来调整Operator
            var searchResults = client.Search<PersonDetail>(s => s
                .Index("elastic-search-app")
                .Query(q => q.QueryString(qs => qs.Query(keyword).DefaultOperator(Operator.And)))
                );

            //--------------------------------------------------------------------------------------
            //另外由于ES是分词搜索，所以当我们要用"One"来搜索完整的单词"JustOne"的时候，就必须在"One"外面添加**，类似于SQL里面的%keyword%，但是这样的做法会导致在用完整的单词来搜索的时候搜索不到结果，所以我们需要使用下面的方式

            //wholeKeyword = keyword;
            //keyword = String.Format("*{0}*", keyword);
            //QueryContainer query = new QueryStringQuery() { Query = keyword, DefaultOperator = Operator.And };
            //if (!String.IsNullOrEmpty(wholeKeyword))
            //{
            //    QueryContainer wholeWordQuery = new QueryStringQuery() { Query = wholeKeyword };
            //    query = query || wholeWordQuery;
            //}
            //var searchResults = client.Search<Person>(s => s
            //    .Index("zhixiao-application")
            //    .Query(query)
            //);

            #endregion

            #region 指定属性搜索

            //使用term Query
            //Term是一个被索引的精确值，也就是说Foo, foo, FOO是不相等的，因此
            //在使用term query的时候要注意，term query在搜索的Field已经被索引的时候，是不支持大写的。
            // QueryContainer query2 = new TermQuery { Field = item.Key, Value = item.Value.ToLower() };
            //--------------------------------------------------------------------------------------
            //var searchResults = client.Search<PersonDetail>(s => s
            //    .Index("elastic-search-app")
            //    .Query(q => q.Term(t => t.OnField(f => f.LastName == "keyword")))
            //);
            //效果同上
            //QueryContainer termQuery = new TermQuery { Field = "lastname", Value = "keyword" };
            //var searchResults = client.Search<PersonDetail>(s => s
            //    .Index("elastic-search-app")
            //    .Query(termQuery)
            //);
            //--------------------------------------------------------------------------------------
            //使用 Query String query
            //QueryString query一般用于全文搜索，但是也可以用于单个属性的搜索（设置DefaultField属性），queryString query可以不区分大小写。QueryString还有一个好处就是我们可以搜索一个term中的一部分，
            //例如lastname为"t Boterhuis 1"，那么我们可以用"terhuis"搜索到这个数据（虽然需要在外面包上**），在term query里面就做不到，因为ES把每一个属性的值都分析成一个个单独的term，提高了搜索的效率。 
            //keyword = "t Boterhuis 2";
            //QueryContainer wholeWordQuery = new QueryStringQuery() { Query = keyword, DefaultOperator = Operator.And };
            //var searchResults = client.Search<PersonDetail>(s => s
            //    .Index("elastic-search-app")
            //    .Query(wholeWordQuery)
            //);

            #endregion

            return searchResults.Documents.ToList();
        }

        public List<PersonDetail> Sort(string keyword)
        {
            // 首先我们把原先的索引先删除了
            var response =
                client.DeleteIndex(
                    new DeleteIndexRequest(new IndexNameMarker()
                    {
                        Name = "elastic-search-app",
                        Type = typeof(PersonDetail)
                    }));

            //然后重新创建索引
            var indexResult = client.CreateIndex("PD-application");
            var response1 = client.Map<PersonDetail>(m => m.MapFromAttributes());
            IEnumerable<PersonDetail> persons = new List<PersonDetail>
            {
                new PersonDetail()
                {
                    Id = 4,
                    FirstName = "Boterhuis-040",
                    LastName = "Gusto-040",
                },
                new PersonDetail()
                {
                    Id = 5,
                    FirstName = "sales@historichousehotels.com",
                    LastName = "t Boterhuis 1",
                },
                new PersonDetail()
                {
                    Id = 6,
                    FirstName = "Aberdeen #110",
                    LastName = "sales@historichousehotels.com",
                },
                new PersonDetail()
                {
                    Id = 7,
                    FirstName = "Aberdeen #110",
                    LastName = "t Boterhuis 2",
                },
            };
            foreach (var person in persons)
            {
                client.Index(person);
            }
            var searchResults = client.Search<PersonDetail>(s => s
                .Index("PD-application")
                .Sort(sort => sort.OnField(f => f.Id).Order(SortOrder.Ascending))

            );
            return searchResults.Documents.ToList();
        }
    }

}
