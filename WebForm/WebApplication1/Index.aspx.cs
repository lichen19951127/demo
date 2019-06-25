using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Index : System.Web.UI.Page
    {
        private static string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString();
        public static string aa = "<option value='1'>1</option><option value='2'>2</ option><option value='3'>3</option>";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //绑定下拉框数据    你可以使用多种方式
                Hashtable Ht = new Hashtable();
                Ht.Add("1", "1月");
                Ht.Add("2", "2月");
                Ht.Add("3", "3月");
                Ht.Add("4", "4月");
                Ht.Add("5", "5月");
                Ht.Add("6", "6月");
                Ht.Add("7", "7月");
                this.DropDownList1.DataSource = Ht;
                this.DropDownList1.DataValueField = "key";
                this.DropDownList1.DataTextField = "value";
                this.DropDownList1.SelectedIndex = 2;
                this.DropDownList1.DataBind();
             
            }

            //bindData();
        }
        void bindData()
        {
            using (var conn = new SqlConnection(conStr))
            {
                var sql = string.Format("select * from Users");
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                conn.Close();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var cname = e.CommandName;
            int RowIndex = Convert.ToInt32(e.CommandArgument);
            //行中的数据;
            DataKey keys = GridView1.DataKeys[RowIndex];
            if (cname == "upd")
            {
                Response.Redirect("update.aspx?id=" + keys.Value);
            }
            else
            {
                using (var conn = new SqlConnection(conStr))
                {
                    var sql = string.Format("delete from Users where Id='{0}'", keys.Value);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        bindData();
                    }
                    conn.Close();
                }
            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = DropDownList1.SelectedItem.Value;
            //如果写死可以这样写  
            switch (a)
            {
                case "1":
                    Label1.Text = "11111";
                    break;
                case "2":
                    Label1.Text = "222222";
                    break;
                case "3":
                    Label1.Text = "333333";
                    break;
                case "4":
                    Label1.Text = "4444";
                    break;
                case "5":
                    Label1.Text = "5555";
                    break;
                case "6":
                    Label1.Text = "666";
                    break;
                case "7":
                    Label1.Text = "77777";
                    break;
            }

            //如果是根据数据库那就去根据选中的这个key值去查数据库在绑定lable
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.DropDownList1.SelectedIndex = 0;
            this.Label1.Text = "清空了";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
          var index=  sel.SelectedIndex;
           var aaa= sel.Value;
          var aaa1=  Request.Form["sel"];
        }
    }
    public class Info
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}