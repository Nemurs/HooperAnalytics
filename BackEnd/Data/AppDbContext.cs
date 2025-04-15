using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DotNetEnv;

namespace BackEnd.Data
{
    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options){

            }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            DotNetEnv.Env.Load();
            options.UseNpgsql(System.Environment.GetEnvironmentVariable("DB__CONNECTION__STRING"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

       new public DbSet<User> Users { get; set; }

    }
}
