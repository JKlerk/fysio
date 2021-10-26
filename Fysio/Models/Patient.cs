using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fysio.Models
{
    public class Patient
    {
        public int Id { get; set; }
        
        [Required]
        public string PatientNumber { get; set; }
        
        [Required]
        public string StaffNumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(1)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        public virtual Image Image { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        
        public virtual PatientFile PatientFile { get; set; }
        public virtual List<Appointment> Appointments { get; set; }

        // public string City { get; set; }
        //
        // public string Street { get; set; }
        //
        // public string Postalcode { get; set; }

        // public string SsNumber { get; set; }
    }
}