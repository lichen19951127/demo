using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System.Data;
    using System.Data.SqlClient;
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection("Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=test;Data Source=127.0.0.1"))
            {
                var sql = "select * from TUser";
                SqlCommand cmd = new SqlCommand(sql,conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                List<TUser> list = dt.AsEnumerable().Select(p => new TUser()
                {
                    Id = p.Field<int>("Id"),
                    Name = p.Field<string>("Name"),
                    Sex = p.Field<string>("Sex"),
                    Hobby = p.Field<string>("Hobby"),
                    Role = p.Field<string>("Role")
                }).ToList();

                Console.ReadKey();
            }                
        }
    }
}
