using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fysio.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string PatientNumber { get; set; }
        
        public string StaffNumber { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
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