using System.Data.Entity.ModelConfiguration;
using BestQA.QueryService.DTOs;

namespace BestQA.Repository.Mapping
{
    public class PostMap : EntityTypeConfiguration<CommentDTO>
    {
        public PostMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Content)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.CommentTo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Post");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.SupportCnt).HasColumnName("SupportCnt");
            this.Property(t => t.OpposeCnt).HasColumnName("OpposeCnt");
            this.Property(t => t.CommentTo).HasColumnName("CommentTo");
            this.Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}
