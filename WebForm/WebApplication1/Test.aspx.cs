using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
            }
        }

        public void InitData()
        {
            DataTable dt = new DataTable();
           
            this.rpList.DataSource = dt;
            this.rpList.DataBind();
        }
        protected void rpList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("rpListSub") as Repeater;//找到里层的repeater对象
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项
                int category = Convert.ToInt32(rowv["DataKey"]);//获取填充子类的id 
                //rep.DataSource = SysData.GetExpertiseLevelDTByCategory(category);
                rep.DataBind();
            }
        }
    }
}