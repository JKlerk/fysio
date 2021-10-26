using System.Collections.Generic;

namespace Fysio.Models
{
    public class PatientViewModel : IViewModel
    {
        public List<Therapist> Therapists;
        public Patient Patient {get;set;}
        public PatientFile PatientFile {get;set;}
        public TreatmentPlan TreatmentPlan { get; set; }
        public Treatment Treatment { get; set; }
        public void SetTherapist(List<Therapist> therapists)
        {
            Therapists = new List<Therapist>();
            Therapists = therapists;
        } 
    }
}