using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FamilyModel> listFamily = new List<FamilyModel>();
            listFamily.Add(new FamilyModel { Name = "bbb" });
            listFamily.Add(new FamilyModel { Name = "abc" });
            listFamily.Add(new FamilyModel { Name = "fgd" });

            // 直接更改当前List
            listFamily.Sort((x, y) => string.Compare(x.Name, y.Name));

            // 生成新的List
            var newList = listFamily.OrderBy(x => x.Name).ToList(); // ToList optional    


            //XmlNodeList list= 

        }
    }
    public class FamilyModel
    {
        public string Name { set; get; }
    }
}
