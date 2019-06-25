using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.Controllers
{
    public class ChenController : Controller
    {
        //加载appsetting.json
        static IConfiguration configuration = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json").Build();



        /// <summary>
        ///
        /// </summary>
        private static readonly string fileText = configuration["conn:head"];
        public IActionResult Index()
        {
            SqlConnection con = new SqlConnection(fileText);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users",con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            var d = dt;
            return View();
        }
    }
}