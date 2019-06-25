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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var json = Client.GetApi("post", "QueryUsers");
                var user = JsonConvert.DeserializeObject<List<Users>>(json);
                gv.DataSource = user;
                gv.DataBind();
            }
      
        }
    }
}