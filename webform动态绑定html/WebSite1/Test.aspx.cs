using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    public string str { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        str = "<a href='www.baidu.com' target='_blank' >点击</a>";

    }
}