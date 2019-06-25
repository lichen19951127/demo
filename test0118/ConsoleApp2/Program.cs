using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    using System.Data;
    using System.Data.SqlClient;
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection("Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=test;Data Source=127.0.0.1"))
            {
                var sql = "select num as NN from table1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                List<TT> list = dt.AsEnumerable().Select(p => new TT()
                {
                    NN = p.Field<double>("NN")
                }).ToList();

              
            }
            Console.ReadKey();
        }
    }


    public class TT
    {
        public double NN { get; set; }
    }
}
