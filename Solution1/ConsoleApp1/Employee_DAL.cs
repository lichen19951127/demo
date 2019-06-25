using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Employee_DAL : IEmployee<Employee>
    {
        public int Add(Employee e)
        {
            return 1;
        }

        public int Delete(string ids)
        {
            return 0;
        }

        public List<Employee> Query()
        {
            return new List<Employee>();
        }

        public int Update(Employee e)
        {
            return -1;
        }
    }
}
