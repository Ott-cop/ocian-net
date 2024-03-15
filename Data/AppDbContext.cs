using Microsoft.EntityFrameworkCore;
using ocian_net.Models;

namespace ocian_net.Data
{
    public class AppDbContext : DbContext
    {      
        readonly DotEnv dotEnv = new DotEnv();
        
        public DbSet<FormSupport> FormSupport { get; set; }
        public DbSet<FormContactUs> FormContactUs { get; set; }
        public DbSet<FormProposal> FormProposal { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            var url = $"Server={dotEnv.SERVER};Port={dotEnv.PORT};Database={dotEnv.DATABASE_NAME};User Id={dotEnv.DB_USER};Password={dotEnv.DB_PASSWORD};";
            optionsBuilder.UseNpgsql(url);
            base.OnConfiguring(optionsBuilder);
        }
    }
}