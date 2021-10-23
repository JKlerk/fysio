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
        public DbSet<TreatmentPlan> TreatmentPlans { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Patient>()
            //     .HasMany(p => p.PatientFile);

            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Patient>().HasOne(p => p.PatientFile).WithOne(pf => pf.Patient);
            modelBuilder.Entity<PatientFile>().ToTable("PatientsFile");
            modelBuilder.Entity<PatientFile>().HasOne(pf => pf.Patient).WithOne(p => p.PatientFile);
            
            // modelBuilder.Entity<PatientFile>().HasOne(pf => pf.Supervisor).WithMany(th => th.Supervised);
            // modelBuilder.Entity<PatientFile>().HasOne(pf => pf.Interviewer).WithMany(th => th.Interviewed);
            // modelBuilder.Entity<PatientFile>().HasOne(pf => pf.Practitioner).WithMany(th => th.Practitioner);

            // modelBuilder.Entity<PatientFile>().HasOne(pf => pf.Interviewer).WithMany(p => p.Interviewed);
            // modelBuilder.Entity<PatientFile>().HasOne(pf => pf.Supervisor).WithMany(p => p.Supervised);
            // modelBuilder.Entity<PatientFile>().HasOne(pf => pf.Practitioner).WithMany(p => p.Practitioner);

            modelBuilder.Entity<Therapist>().ToTable("Therapists");
            // modelBuilder.Entity<Therapist>().HasMany(t => t.PatientFiles).WithOne(pf => pf.Practitioner);
            
            modelBuilder.Entity<TreatmentPlan>().ToTable("TreatmentPlans");
            modelBuilder.Entity<TreatmentPlan>().HasMany(tp => tp.Treatments).WithOne(t => t.TreatmentPlan);       
            
            modelBuilder.Entity<Treatment>().ToTable("Treatments");
            modelBuilder.Entity<Treatment>().HasOne(t => t.TreatmentPlan).WithMany(tp => tp.Treatments);
        }
    }
}