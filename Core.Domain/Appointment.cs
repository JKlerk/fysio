using System;

namespace Core.Domain
{
    public class Appointment
    {
        public int Id { get; set; }
        
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        
        public int TherapistId { get; set; }
        public virtual Therapist Therapist { get; set; }

        public int? TreatmentId { get; set; }
        public virtual Treatment Treatment { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime Date { get; set; }
    }
}