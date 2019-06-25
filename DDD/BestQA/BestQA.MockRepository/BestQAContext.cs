using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BestQA.QueryService.DTOs;
using BestQA.Repository.Mapping;

namespace BestQA.Repository.Models
{
    public partial class BestQAContext : DbContext
    {
        static BestQAContext()
        {
            Database.SetInitializer<BestQAContext>(null);
        }

        public BestQAContext()
            : base("Name=BestQAContext")
        {
        }

        public DbSet<AnswerDTO> Answers { get; set; }
        public DbSet<CommentDTO> Posts { get; set; }
        public DbSet<QuestionDTO> Questions { get; set; }
        public DbSet<TagDTO> Tags { get; set; }
        public DbSet<UserDTO> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
