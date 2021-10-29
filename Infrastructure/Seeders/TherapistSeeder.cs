using System;
using System.Collections.Generic;
using Core.Domain;

namespace Infrastructure.Seeders
{
    public class TherapistSeeder
    {

        public List<Therapist> therapists { get; }

        public TherapistSeeder()
        {
            List<Therapist> data = new List<Therapist>();
            
            data.Add(
                new Therapist()
                {
                    Id = 1,
                    Name="Pascal Stoop",
                    Email="p.stoop@avans.nl", 
                    PhoneNumber= "0612121212", 
                    BigNumber = "12345678901", 
                    StudentNumber = "null", 
                    ScheduleStart = DateTime.Now,
                    ScheduleEnd = DateTime.Now.AddYears(1),
                }
            );
            
            data.Add(
                new Therapist()
                {
                    Id = 2,
                    Name="Ali Biyikli",
                    Email="a.biyikli@avans.nl", 
                    PhoneNumber= "0612121212", 
                    BigNumber = "12345678901", 
                    StudentNumber = "null", 
                    ScheduleStart = DateTime.Now,
                    ScheduleEnd = DateTime.Now.AddYears(1),
                }
            );

            therapists = data;
        }
    }
}