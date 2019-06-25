using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    //Fluent API配置Configuration映射类
    public class PersonDetailMap :EntityTypeConfiguration<PersonDetail>
    {
        public PersonDetailMap()
        {
            // 主键
            this.HasKey(t => new { t.Id, t.FirstName, t.LastName });

            // 属性
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.FirstName)
                .IsRequired();

            this.Property(t => t.LastName)
                .IsRequired();

            // 表 & 列 映射
            this.ToTable("PersonDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
        }
    }

}
