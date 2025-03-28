using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DotNetEnv;

namespace BackEnd.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            DotNetEnv.Env.Load();
            options.UseNpgsql(System.Environment.GetEnvironmentVariable("DB__CONNECTION__STRING"));
        }

        public DbSet<User> Users { get; set; }
    }
}
