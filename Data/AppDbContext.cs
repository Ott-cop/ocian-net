using Microsoft.EntityFrameworkCore;
using ocian_net.Models;

namespace ocian_net.Data
{
    public class AppDbContext : DbContext
    {      
        
        public DbSet<FormSupport> FormSupport { get; set; }
        public DbSet<FormContactUs> FormContactUs { get; set; }
        public DbSet<FormProposal> FormProposal { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            var dotEnv = new DotEnv();
            var url = $"Server={dotEnv.SERVER};Port={dotEnv.PORT};Database={dotEnv.DATABASE_NAME};User Id={dotEnv.DB_USER};Password={dotEnv.DB_PASSWORD};";
            optionsBuilder.UseNpgsql(url);
            base.OnConfiguring(optionsBuilder);
        }
    }
}