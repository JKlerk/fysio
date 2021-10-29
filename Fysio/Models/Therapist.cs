using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fysio.Models;

namespace Fysio.Models
{
    public class Therapist
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        
        [DataType(DataType.Date, ErrorMessage = "Enter a valid date")]
        public DateTime ScheduleStart { get; set; }
        
        [DataType(DataType.Date, ErrorMessage = "Enter a valid date")]
        public DateTime ScheduleEnd { get; set; }
        public string StudentNumber { get; set; }

        public string BigNumber { get; set; }
        
        public virtual List<Appointment> Appointments { get; set; }
        
        public virtual List<PatientFile> PatientFiles { get; set; }

    }
}