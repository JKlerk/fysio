using System;
using System.Collections.Generic;
using Core.Domain;

namespace Infrastructure.Seeders
{
    public class PatientFileSeeder
    {

        public List<PatientFile> patientFiles { get; }

        public PatientFileSeeder(List<Therapist> therapists, List<Patient> patients)
        {
            List<PatientFile> data = new List<PatientFile>();
            data.Add(
                new PatientFile {
                    Id = 1,
                    Age = 18, 
                    Description = "Big description", 
                    DiagnoseCode = "BCH-1000", 
                    InterviewerId = therapists[0].Id, 
                    SupervisorId = therapists[0].Id, 
                    PractitionerId = therapists[0].Id, 
                    RegisterDate = DateTime.Parse("2002-09-01"),
                    TherapistType = "Student",
                    PatientId = patients[0].Id
                }
            );

            patientFiles = data;
        }
    }
}