using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Infrastructure;
using Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Fysio.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FysioContext context)
        {
            context.Database.EnsureCreated();
            if (context.Patients.Any())
            {
                return;   // DB has been seeded
            }
            List<Patient> patientsSeeder = new PatientSeeder().patients; 
            List<Therapist> therapistsSeeder = new TherapistSeeder().therapists;

            context.Patients.AddRange(patientsSeeder);
            context.Therapists.AddRange(therapistsSeeder);
            context.SaveChanges();
            //
            // List<Image> imageSeeder = new ImageSeeder(context.Patients.ToList()).Images;
            // context.Images.AddRange(imageSeeder);
            // context.SaveChanges();
            
            
            List<PatientFile> patientFileSeeder = new PatientFileSeeder(context.Therapists.ToList(), context.Patients.ToList()).patientFiles;
            context.PatientFiles.AddRange(patientFileSeeder);
                
            context.SaveChanges();
        }
    }
}