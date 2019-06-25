using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewLife.XCode.WebNet.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            //查询
            string sql = "SELECT * FROM serverinfo WHERE Name =@ServerName AND Url = @Url and date(CreateTime)=date(@Date);";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("ServerName", endpointElement.Name);
            parameters.Add("Url", endpointElement.Address);
            parameters.Add("Date", DateTime.Now.ToString("yyyy-MM-dd"));
            DataTable dt = SQLiteHelper.ExecuteQuery(connStr, sql, parameters);
            if (dt.Rows.Count > 0)
            {
                UsageCounter = dt.Rows[0].Field<long>("UsageCounter");
                GetTime = dt.Rows[0].Field<DateTime>("CreateTime");
            }



            return View();
        }


        public bool Add()
        {
            //存在更新，不存在插入
            string updateSql = "REPLACE INTO serverinfo(Name,Url,DelayTime,UsageCounter, Status,CreateTime) VALUES(@Name,@Url,@DelayTime,@UsageCounter,@Status, @CreateTime)";
            Dictionary<string, object> ups = new Dictionary<string, object>();
            ups.Add("Name", name);
            ups.Add("Url", url);
            ups.Add("DelayTime", delayTime);
            ups.Add("UsageCounter", usageCounter);
            ups.Add("Status", status);
            ups.Add("CreateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            int count = SQLiteHelper.ExecuteNonQuery(connStr, updateSql, ups);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete()
        {
            //删除记录
            string updateSql =
                "DELETE FROM serverinfo where content=@Content and flag=@Flag;";
            Dictionary<string, object> updateParameters = new Dictionary<string, object>();
            updateParameters.Add("Content", Content);
            updateParameters.Add("Flag", Flag);
            int count = SqliteHelper.ExecuteNonQuery(connStr, updateSql, updateParameters);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}