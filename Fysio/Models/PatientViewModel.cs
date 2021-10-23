using System.Collections.Generic;

namespace Fysio.Models
{
    public class PatientViewModel
    {
        public List<Core.Domain.Therapist> Therapists { get; set; }
        public Core.Domain.Patient Patient {get;set;}
        public Core.Domain.PatientFile PatientFile {get;set;}
        public Core.Domain.TreatmentPlan TreatmentPlan { get; set; }
        public Core.Domain.Treatment Treatment { get; set; }
    }
}