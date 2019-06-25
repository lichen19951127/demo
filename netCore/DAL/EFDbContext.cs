using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.SqlServer;
    using Microsoft.Extensions.Options;

    public class EFDbContext:DbContext
    {
        //private readonly IOptions<ConnectionSettings> connectionSetting;
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
            //connectionSetting = _connectionSetting;
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connStr = connectionSetting.Value.ConnectionStrings;
        //    //注入Sql链接字符串
        //    optionsBuilder.UseSqlServer(connStr);
        //}
        public DbSet<Users> Users { get; set; }
    }
}
