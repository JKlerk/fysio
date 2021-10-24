﻿using System;
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
                    Name="Kate Velasquez",
                    Email="test@test.com", 
                    PhoneNumber= "0612121212", 
                    Gender = "Male", 
                    Birthdate = DateTime.Parse("2002-09-01"), 
                    PatientNumber = Guid.NewGuid().ToString(), 
                    StaffNumber = "2168734"
                }
            );
            
            data.Add(
                new Patient {
                    Name="Emily Fariello",
                    Email="test@test.com", 
                    PhoneNumber= "0612121212", 
                    Gender = "Male", 
                    Birthdate = DateTime.Parse("2002-09-01"), 
                    PatientNumber = Guid.NewGuid().ToString(), 
                    StaffNumber = "2168734"
                }
            );
            
            patients = data;
        }
    }
}