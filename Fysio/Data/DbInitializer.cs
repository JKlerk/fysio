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
            
            List<Patient> patientsSeeder = new PatientSeeder().patients; 
            List<Therapist> therapistsSeeder = new TherapistSeeder().therapists;

            context.Patients.AddRange(patientsSeeder);
            context.Therapists.AddRange(therapistsSeeder);
            context.SaveChanges();
            
            List<PatientFile> patientFileSeeder = new PatientFileSeeder(context.Therapists.ToList(), context.Patients.ToList()).patientFiles;
            context.PatientFiles.AddRange(patientFileSeeder);
                
            context.SaveChanges();
        }
    }
}