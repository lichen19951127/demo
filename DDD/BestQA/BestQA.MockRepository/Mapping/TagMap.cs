using System.Data.Entity.ModelConfiguration;
using BestQA.QueryService.DTOs;

namespace BestQA.Repository.Mapping
{
    public class TagMap : EntityTypeConfiguration<TagDTO>
    {
        public TagMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TagTo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Tag");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TagTo).HasColumnName("TagTo");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
