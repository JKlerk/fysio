using System;
using System.Collections.Generic;
using Core.Domain;

namespace Infrastructure.Seeders
{
    public class PatientSeeder
    {

        public List<Patient> patients { get; }

        public PatientSeeder()
        {
            List<Patient> data = new List<Patient>();
            data.Add(
                new Patient {
                    Id = 1,
                    Name="Kate Velasquez",
                    Email="kate@test.com", 
                    PhoneNumber= "0612121212", 
                    Gender = "Female", 
                    Birthdate = DateTime.Parse("2002-09-01"), 
                    PatientNumber = Guid.NewGuid().ToString(), 
                    StaffNumber = "2168734"
                }
            );
            
            data.Add(
                new Patient {
                    Id = 2,
                    Name="Emily Fariello",
                    Email="emily@test.com", 
                    PhoneNumber= "0612121212", 
                    Gender = "Female", 
                    Birthdate = DateTime.Parse("2002-09-01"), 
                    PatientNumber = Guid.NewGuid().ToString(), 
                    StaffNumber = "2168734"
                }
            );
            
            patients = data;
        }
    }
}