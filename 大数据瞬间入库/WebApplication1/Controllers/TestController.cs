using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Content;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public static string conn = System.Configuration.ConfigurationManager.ConnectionStrings["ITS"].ToString();
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int UpLoad()
        {
            var result = 0;
            var file = Request.Files["file"];
            if (file != null)
            {
                var f = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                if (f.Equals(".xls") || f.Equals(".xlsx"))
                {
                    //result = ExcelHelper1.ExcelAdd(file, "");
                    var getPath = Server.MapPath("/ExcelFile/");
                    if (!Directory.Exists(getPath))
                    {
                        Directory.CreateDirectory(getPath);
                    }
                    var fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + f;
                    var newPath = Path.Combine(getPath, fileName);
                    file.SaveAs(newPath);

                    

                    var dts = ExcelHelper.GetDataTable(newPath);

                    var service = new MallCRMService();

                    List<MallCustomer> customers = new List<MallCustomer>();
                    for (int k = 0; k < dts.Rows.Count; k++)
                    {
                        var row = dts.Rows[k];//读取当前行数据
                        if (row != null)
                        {
                            DataRow dr;
                            MallCustomer customer = new MallCustomer();
                            List<MallCustomerContact> contacts = new List<MallCustomerContact>();
                            MallCustomerContact con = new MallCustomerContact();
                            //LastRowNum 是当前表的总行数-1
                            for (int j = 0; j < row.ItemArray.Length - 1; j++)
                            {
                                if (j == 0)
                                {
                                    continue;
                                }
                                //读取该行的第j列数据
                                //var value = row.GetCell(j).ToString();
                                customer.Company = row.ItemArray[1].ToString();
                                customer.Address = row.ItemArray[2].ToString();
                                customer.Business = row.ItemArray[3].ToString();
                                customer.RegCapital = Convert.ToDecimal(row.ItemArray[4].ToString() == "" ? "0" : row.ItemArray[4].ToString());
                                customer.EmployeesNum = Convert.ToInt32(row.ItemArray[5].ToString() == "" ? "0" : row.ItemArray[5].ToString());
                                customer.Boss = row.ItemArray[6].ToString();
                                //联系人
                                con.Name = row.ItemArray[7].ToString();
                                con.Mobile = row.ItemArray[8].ToString();
                                customer.Remark = row.ItemArray[9].ToString();


                                customer.Createtime = DateTime.Now;
                                customer.Description = "";
                                customer.Level = "";
                                customer.PrePurchase = 0;
                                customer.Status = WebApplication1.Content.MallCustomerStates.公池;
                                customer.StatusTime = DateTime.Now;
                                customer.Type = WebApplication1.Content.MallCustomerType.潜在意向客户;
                                customer.TypeTime = DateTime.Now;
                                customer.YewuId = 0;
                                customer.YewuName = "";
                                customer.IsDel = false;
                                con.Createtime = DateTime.Now;

                                var cusNum = customers.Where(m => m.Company.Equals(customer.Company)).FirstOrDefault();
                                if (cusNum != null)
                                {
                                    List<string> list = cusNum.Remark.Split(',').ToList();
                                    list.Add(customer.Remark);


                                    list = list.Distinct().ToList();
                                    var remark = "";
                                    for (int q = 0; q < list.Count; q++)
                                    {
                                        remark += list[q] + ",";
                                    }
                                    cusNum.Remark = remark.TrimEnd(',');
                                }
                                else
                                {
                                    customers.Add(customer);
                                    continue;
                                }
                            }
                            contacts.Add(con);

                        }
                    }
                    //批量添加
                    var aaa= service.AddMallCustomerList(customers);

                    //转成datatable 再插入
                 
                }
                else
                {
                    result = -2;
                }
            }
            else
            {
                result = -1;
            }
            return result;
        }


        #region 使用SqlBulkCopy将DataTable中的数据批量插入数据库中
        /// <summary>  
        /// 注意：DataTable中的列需要与数据库表中的列完全一致。/// </summary>  
        /// <param name="conStr">数据库连接串</param>
        /// <param name="strTableName">数据库中对应的表名</param>  
        /// <param name="dtData">数据集</param>  
        public static void SqlBulkCopyInsert(string conStr, string strTableName, DataTable dtData)
        {
            try
            {
                using (SqlBulkCopy sqlRevdBulkCopy = new SqlBulkCopy(conStr))           //引用SqlBulkCopy  
                {
                    sqlRevdBulkCopy.DestinationTableName = strTableName;                //数据库中对应的表名  
                    sqlRevdBulkCopy.NotifyAfter = dtData.Rows.Count;                    //有几行数据  
                    sqlRevdBulkCopy.WriteToServer(dtData);                              //数据导入数据库  
                    sqlRevdBulkCopy.Close();                                            //关闭连接  
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}