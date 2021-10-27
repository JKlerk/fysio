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
        public DbSet<TreatmentType> TreatmentType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>().ToTable("diagnose");
            modelBuilder.Entity<TreatmentType>().ToTable("treatmenttype");
        }
    }
}