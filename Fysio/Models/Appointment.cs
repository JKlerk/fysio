using System;
using System.ComponentModel.DataAnnotations;

namespace Fysio.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        
        public int TherapistId { get; set; }
        public Therapist Therapist { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}