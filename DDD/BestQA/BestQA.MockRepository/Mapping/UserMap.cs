using System.Data.Entity.ModelConfiguration;
using BestQA.QueryService.DTOs;

namespace BestQA.Repository.Mapping
{
    public class UserMap : EntityTypeConfiguration<UserDTO>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Money)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Money).HasColumnName("Money");
            this.Property(t => t.Id).HasColumnName("Id");
        }
    }
}
