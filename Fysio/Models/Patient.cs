using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fysio.Validators;

namespace Fysio.Models
{
    public class Patient
    {
        public int Id { get; set; }
        
        public string PatientNumber { get; set; }
        
        [Required]
        [IsNumber]
        public string StaffNumber { get; set; }

        public string BigNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [UniqueEmail]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        public virtual Image Image { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Enter a valid date")]
        [MinimumAge(16, ErrorMessage = "User is not old enough to be a patient")]
        [NotFuture(ErrorMessage = "Birthdate can not be in the future")]
        public DateTime Birthdate { get; set; }
        
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        
        public virtual PatientFile PatientFile { get; set; }
        public virtual List<Appointment> Appointments { get; set; }
    }
}