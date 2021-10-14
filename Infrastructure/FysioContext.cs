using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class FysioContext : DbContext
    {
        public FysioContext(DbContextOptions<FysioContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<PatientFile> PatientFiles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Patient>()
            //     .HasMany(p => p.PatientFile);

            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Therapist>().ToTable("Therapists");
            modelBuilder.Entity<PatientFile>().ToTable("PatientsFile");
        }
    }
}