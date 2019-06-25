using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Business
    {
        private List<PersonDetail> _personList = new List<PersonDetail>();

        //SQLSERVER数据库
        PersonDbProvider dbProvider = new PersonDbProvider();

        //ElasticSearch
        ESProvider esProvider = new ESProvider();

        public void AddToDb()
        {
            _personList = Util.Get10000PersonDetails();//辅助类,生成10000条数据

            foreach (var personDetail in _personList)
            {
                dbProvider.AddPerson(personDetail);
            }
        }

        public void AddToElasticIndex()
        {
            _personList = Util.Get10000PersonDetailsWithID();
            foreach (var personDetail in _personList)
            {
                esProvider.Index(personDetail);
            }
        }

        public List<PersonDetail> GetFromDB()
        {
            return dbProvider.GetAllPersonDetails();
        }

        public List<PersonDetail> GetFromES()
        {
            return esProvider.GetAll();
        }

    }
}
