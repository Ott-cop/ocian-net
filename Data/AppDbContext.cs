using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ocian_net.Models;

namespace ocian_net.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CommonFormModel> CommonForm { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=ocian_db;User Id=postgres;Password=root;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}