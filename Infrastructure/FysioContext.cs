using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Infrastructure.Seeders;
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
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Patient>().HasOne(p => p.PatientFile).WithOne(pf => pf.Patient).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Therapist>().ToTable("Therapists");
            
            modelBuilder.Entity<PatientFile>().ToTable("PatientsFile");
            modelBuilder.Entity<PatientFile>().HasOne(pf => pf.Patient).WithOne(p => p.PatientFile).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PatientFile>().HasOne(pf => pf.TreatmentPlan).WithOne(tp => tp.PatientFile).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TreatmentPlan>().ToTable("TreatmentPlans");
            modelBuilder.Entity<TreatmentPlan>().HasOne(tp => tp.PatientFile).WithOne(pf => pf.TreatmentPlan).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TreatmentPlan>().HasMany(tp => tp.Treatments).WithOne(t => t.TreatmentPlan).OnDelete(DeleteBehavior.Cascade);       
            
            modelBuilder.Entity<Treatment>().ToTable("Treatments");
            modelBuilder.Entity<Treatment>().HasOne(t => t.TreatmentPlan).WithMany(tp => tp.Treatments)
                .OnDelete(DeleteBehavior.Cascade);
        }
        
        
    }
}