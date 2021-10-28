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

            var records = new List<Diagnose>();
            using (var reader = new StreamReader("../Infrastructure.WebService/Files/Vektis_diagnose.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                int inc = 1;
                while (csv.Read())
                {
                    var record = new Diagnose()
                    {
                        Id = inc,
                        DiagnoseCode = csv.GetField<string>("Code") != "" ? csv.GetField<Int16>("Code") : null,
                        BodyLocation = csv.GetField<string>("lichaamslocalisatie"),
                        Pathology = csv.GetField<string>("pathologie")
                    };
                    inc++;
                    records.Add(record);
                }
            }
            modelBuilder.Entity<Diagnose>().HasData(records);
            
            modelBuilder.Entity<TreatmentType>().ToTable("treatmenttype");
            
            var records2 = new List<TreatmentType>();
            using (var reader = new StreamReader("../Infrastructure.WebService/Files/Vektis_treatment.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                int inc = 1;
                while (csv.Read())
                {
                    var record = new TreatmentType
                    {
                        Id = inc,
                        TreatmentCode = csv.GetField<string>("Waarde"),
                        Description = csv.GetField<string>("Omschrijving"),
                        ExplanationRequired = csv.GetField<string>("Toelichting verplicht"),
                    };
                    inc++;
                    records2.Add(record);
                }
            }
            
            modelBuilder.Entity<TreatmentType>().HasData(records2);
            
        }
    }
}