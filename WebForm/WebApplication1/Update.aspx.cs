using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Update : System.Web.UI.Page
    {
        private static string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var conn = new SqlConnection(conStr))
                {
                    int id = Convert.ToInt32(Request["id"]);
                    var sql = string.Format("select * from Users where Id='{0}'", id);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    TextBox1.Text = dt.Rows[0]["Name"].ToString();
                    TextBox2.Text = dt.Rows[0]["Id"].ToString();
                    conn.Close();
                }
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var id = TextBox2.Text;
            var name = TextBox1.Text;

            using (var conn = new SqlConnection(conStr))
            {
                var sql = string.Format("update Users set Name='{0}' where Id='{1}'", name,id);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
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