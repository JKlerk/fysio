using System.Collections.Generic;

namespace Fysio.Models
{
    public class AppointmentViewModel : IViewModel
    {
        public List<Therapist> Therapists { get; set; }

        public Patient Patient { get; set; }
        public Appointment Appointment { get; set; }
        public List<Treatment> Treatments { get; set; }

        public void SetTherapist(List<Therapist> therapists)
        {
            Therapists = new List<Therapist>();
            Therapists = therapists;
        } 
    }
}