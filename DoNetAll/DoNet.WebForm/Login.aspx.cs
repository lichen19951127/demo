using DoNet.Common;
using DoNet.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNet.WebForm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var json = Client.GetApi("post", "Login?name=" + txtName.Text + "&pwd=" + txtName.Text);
            var user = JsonConvert.DeserializeObject<Users>(json);
            var result = "";
            if (user != null)
                result = "alert('success');location.href='Index.aspx'";
            else
                result = "alert('error')";
            Response.Write("<script>" + result + "</script>");
        }
    }
}