using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Index : System.Web.UI.Page
    {
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
        }
    }
}