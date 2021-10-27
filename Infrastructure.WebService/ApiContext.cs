using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.WebService
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Diagnose> Diagnose { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>().ToTable("diagnose");
        }
    }
}