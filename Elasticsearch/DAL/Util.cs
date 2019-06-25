using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Util
    {
        //生成10000条sqlserver测试数据
        public static List<PersonDetail> Get10000PersonDetails()
        {
            var personDetailsList = new List<PersonDetail>();

            for (int i = 0; i < 10000; i++)
            {
                personDetailsList.Add(new PersonDetail()
                {
                    FirstName = "FN" + new Random().Next(int.MaxValue),
                    LastName = "LN" + new Random().Next(int.MaxValue)
                });
            }
            return personDetailsList;
        }

        //生成10000条ElasticSearch测试数据
        public static List<PersonDetail> Get10000PersonDetailsWithID()
        {
            var personDetailsList = new List<PersonDetail>();

            for (int i = 0; i < 10000; i++)
            {
                personDetailsList.Add(new PersonDetail()
                {
                    Id = i * new Random().Next(99),
                    FirstName = "FN" + new Random().Next(int.MaxValue),
                    LastName = "LN" + new Random().Next(int.MaxValue)
                });
            }
            return personDetailsList;
        }
    }
}
