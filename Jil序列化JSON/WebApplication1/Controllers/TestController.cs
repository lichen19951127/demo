using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class TestController : ApiController
    {
        public static List<Market> Markets = new List<Market>();

        public TestController()
        {

        }

        static TestController()
        {
            Markets.Add(new Market { Id = 1, Name = "1", DateTimeNow = DateTime.Now });
            Markets.Add(new Market { Id = 2, Name = "1", DateTimeNow = DateTime.Now });
            Markets.Add(new Market { Id = 3, Name = "1", DateTimeNow = DateTime.Now });
            Markets.Add(new Market { Id = 4, Name = "1", DateTimeNow = DateTime.Now });
            Markets.Add(new Market { Id = 5, Name = "1", DateTimeNow = DateTime.Now });
        }
        public IEnumerable<Market> Get()
        {
            return Markets;
        }
        public HttpResponseMessage Post([FromBody]Market value)
        {
            Markets.Add(value);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put(int id, [FromBody]Market value)
        {
            var market = Markets.Where(x => x.Id == id).FirstOrDefault();
            if (market == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            market.Name = value.Name;
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(int id)
        {
            var result = Markets.Remove(Markets.Where(x => x.Id == id).FirstOrDefault());
            return result
                ? new HttpResponseMessage(HttpStatusCode.Accepted)
                : new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
    public class Market
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTimeNow { get; set; }
    }
}
