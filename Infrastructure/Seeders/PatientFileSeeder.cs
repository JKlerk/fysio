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
                    Age = 18, Description = "Big description", 
                    DiagnoseCode = "BCH-1000", 
                    InterviewerId = therapists[0].Id, 
                    SupervisorId = therapists[0].Id, 
                    PractitionerId = therapists[0].Id, 
                    RegisterDate = DateTime.Parse("2002-09-01"), 
                    Notes = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Qui molestiae unde voluptates aperiam quas quaerat minus perferendis tenetur fuga provident, nemo abexplicabo vitae at numquam quo. Dolorum, enim saepe.", 
                    TherapistType = "Student",
                    PatientId = patients[0].Id
                }
            );

            patientFiles = data;
        }
    }
}