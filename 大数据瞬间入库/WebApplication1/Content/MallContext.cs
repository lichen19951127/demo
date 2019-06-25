using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication1.Content
{
    public class MallContextInitializer : CreateDatabaseIfNotExists<MallContext>
    {
        protected override void Seed(MallContext context)
        {
            base.Seed(context);
        }
    }
    public class MallContext : DbContext
    {
        public MallContext() : base("ITS")
        {
            Database.SetInitializer<MallContext>(new MallContextInitializer());
        }




        /// <summary>
        /// 客户表
        /// </summary>
        public DbSet<MallCustomer> MallCustomer { get; set; }
        /// <summary>
        /// 客户联系人
        /// </summary>
        public DbSet<MallCustomerContact> MallCustomerContact { get; set; }

    }
}
