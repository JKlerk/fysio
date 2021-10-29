using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Core.Domain;
using CsvHelper;
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
            modelBuilder.Entity<Diagnose>().ToTable("diagnose").HasKey(k => k.Id);
            modelBuilder.Entity<TreatmentType>().ToTable("treatmenttype");

        }
    }
}