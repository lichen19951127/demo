using EntityFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Content
{
    public class MallCRMService
    {
        #region 客户管理

        /// <summary>
        /// 批量插入 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddMallCustomerList(List<MallCustomer> model)
        {
            var result = 0;
            using (MallContext db = new MallContext())
            {
                EFBatchOperation.For(db, db.MallCustomer).InsertAll(model);
            }
            return result;
        }
        public List<MallCustomer> QueryMallCustomer()
        {
            List<MallCustomer> result = null;
            using (MallContext db = new MallContext())
            {
                result = db.MallCustomer.ToList();
            }
            return result;
        }

        #endregion



        #region 公共
        public static IQueryable<MallCustomerContact> GetCustomerContacts(MallContext db, bool? isDel = false)
        {
            var query = from c in db.MallCustomerContact select c;
            if (isDel == null)
                return query;
            else
            {
                return query.Where(x => x.IsDel == isDel);
            }
        }
        /// <summary>
        /// 统一获取客户查询
        /// </summary>
        public static IQueryable<MallCustomer> GetCustomers(MallContext db, bool? isDel = false)
        {
            var query = from c in db.MallCustomer select c;
            if (isDel == null)
                return query;
            else
            {
                return query.Where(x => x.IsDel == isDel);
            }
        }


        /// <summary>
        /// 获取客户的所有联系人
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static List<MallCustomerContact> GetContacts(int customerId)
        {
            using (var db = new MallContext())
            {
                return GetCustomerContacts(db).Where(x => x.CustomerId == customerId).ToList();
            }
        }

        /// <summary>
        /// 根据客户ID获取联系人集合
        /// </summary>
        /// <param name="Id">商品Id</param>
        /// <returns></returns>
        public List<MallCustomerContact> GetMallCustomerContact(int Id)
        {
            var result = new List<MallCustomerContact>();
            using (MallContext db = new MallContext())
            {
                var contactList = db.MallCustomerContact.Where(m => m.CustomerId.Equals(Id) && m.IsDel == false).ToList();
                if (contactList != null)
                {
                    result = contactList;
                }
            }
            return result;
        }


        #endregion
    }
}