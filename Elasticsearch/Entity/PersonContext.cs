using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    using System.Data.Entity;
    public partial class PersonContext : DbContext
    {
        static PersonContext()
        {
            Database.SetInitializer<PersonContext>(null);
        }

        public PersonContext()
            : base("Name=PersonContext")
        {
        }

        public DbSet<PersonDetail> PersonDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //在重写OnModelCreating方法中则可以直接调用映射类，从而减少了OnModelCreating方法的复杂度，同时也增强了代码维护的可读性
            modelBuilder.Configurations.Add(new PersonDetailMap());  //属性映射约定
        }
    }

}
