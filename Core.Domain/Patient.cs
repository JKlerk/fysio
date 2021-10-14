using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Patient
    {
        public int Id { get; set; }

        public string PatientNumber { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public ICollection<PatientFile> PatientFiles { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        // public string City { get; set; }
        //
        // public string Street { get; set; }
        //
        // public string Postalcode { get; set; }

        // public string SsNumber { get; set; }
    }
}