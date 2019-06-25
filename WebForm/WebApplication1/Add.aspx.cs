using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Add : System.Web.UI.Page
    {
        private static string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var name = TextBox1.Text;

            using (var conn=new SqlConnection(conStr))
            {
                var sql = string.Format("insert into Users values('{0}')",name);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql,conn);
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Response.Write("success");
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Response.Write("error");
                }
                conn.Close();
            }
        }
    }
}