using System;
using System.Linq;
using Core.Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Fysio.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FysioContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Patients.Any())
            {
                return;   // DB has been seeded
            }

            var patients = new Patient[]
            {
            new Patient{ Name="Carson",Email="test@test.com", PhoneNumber= "0612121212", Gender = "Male", Birthdate = DateTime.Parse("2002-09-01"), PatientNumber = Guid.NewGuid().ToString(), StaffNumber = "2168734"},
            };
            foreach (Patient s in patients)
            {
                context.Patients.Add(s);
            }
            
            // var files = context.Patients.OrderBy(e => e.Name).Include(e => e.PatientFiles).First();
            // context.Remove(files);
            context.SaveChanges();

            var therapists = new Therapist[]
            {
                new Therapist{ Name="Carson",Email="test@test.com", Password = "secret", PhoneNumber= "0612121212", BigNumber = "12345678901", StudentNumber = "null", AvailableDate = DateTime.Parse("2002-09-01").ToString()},
            };
            foreach (Therapist c in therapists)
            {
                context.Therapists.Add(c);
            }
            
            context.SaveChanges();

            var pf = new PatientFile[]
            {
            new PatientFile
            {
                Age = 18, Description = "asdsadsad", 
                DiagnoseCode = "asdsadsa", 
                InterviewerId = therapists[0].Id, 
                SupervisorId = therapists[0].Id, 
                PractitionerId = therapists[0].Id, 
                RegisterDate = DateTime.Parse("2002-09-01"), 
                Notes = "Empty", 
                TherapistType = "Student",
                PatientId = patients[0].Id
            },
            };
            foreach (PatientFile e in pf)
            {
                context.PatientFiles.Add(e);
            }
            context.SaveChanges();
        }
    }
}