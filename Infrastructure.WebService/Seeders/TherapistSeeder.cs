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
                    Name="Pascal Stoop",
                    Email="p.stoop@avans.nl", 
                    PhoneNumber= "0612121212", 
                    BigNumber = "12345678901", 
                    StudentNumber = "null", 
                    AvailableDate = DateTime.Parse("2002-09-01").ToString()
                }
            );
            
            data.Add(
                new Therapist()
                {
                    Name="Ali Biyikli",
                    Email="a.biyikli@avans.nl", 
                    PhoneNumber= "0612121212", 
                    BigNumber = "12345678901", 
                    StudentNumber = "null", 
                    AvailableDate = DateTime.Parse("2002-09-01").ToString()
                }
            );

            therapists = data;
        }
    }
}