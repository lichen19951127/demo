using System.Data.Entity.ModelConfiguration;
using BestQA.QueryService.DTOs;

namespace BestQA.Repository.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<AnswerDTO>
    {
        public AnswerMap()
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

            this.Property(t => t.AnswerTo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Answer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.SupportCnt).HasColumnName("SupportCnt");
            this.Property(t => t.OpposeCnt).HasColumnName("OpposeCnt");
            this.Property(t => t.AnswerTo).HasColumnName("AnswerTo");
            this.Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.State).HasColumnName("State");
        }
    }
}
