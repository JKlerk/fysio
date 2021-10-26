using System.Collections.Generic;

namespace Fysio.Models
{
    public class AppointmentViewModel
    {
        public List<Core.Domain.Therapist> Therapists { get; set; }
        public Core.Domain.Appointment Appointment { get; set; }
        public List<Core.Domain.Treatment> Treatments { get; set; }
        
    }
}