using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Content
{
    public class EFDBContext: DbContext
    {
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {

        }
 
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Users>(pc =>
        //    {
        //        pc.ToTable("Users").HasKey(k => k.Id);
        //        pc.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        //    }).Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        //}
        public DbSet<Users> Users { get; set; }
    }
}
