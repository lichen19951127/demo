using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oracle
{
    using System.Data;
    using System.Data.OracleClient;
    using MyOraComm;
    class Program
    {
        static void Main(string[] args)
        {
           // ConnForOracle conn = new ConnForOracle("connStr");
           //var ds= conn.ReturnDataSet("select * from Users","aaa").Tables[0];


            using (OracleConnection conn = new OracleConnection("data source=orcl;User Id=scott;Password=tiger;"))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from Users";
                    // cmd.Parameters.AddRange(parameters);
                    OracleDataAdapter ada = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);
                   var aa= ds.Tables[0];
                }
            }
            Console.ReadKey();
        }
    }
}
