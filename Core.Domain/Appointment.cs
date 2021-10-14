using System;

namespace Core.Domain
{
    public class Appointment
    {
        public int Id { get; set; }
        
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        
        public int TherapistId { get; set; }
        public Therapist Therapist { get; set; }

        public string Description { get; set; }
        
        public DateTime Date { get; set; }
    }
}