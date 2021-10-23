using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class PatientFile
    {
        public int Id { get; set; }
        
        public int Age { get; set; }

        public string Description { get; set; }

        public string DiagnoseCode { get; set; }

        public int? InterviewerId { get; set; }
        public Therapist Interviewer { get; set; }

     
        public int? SupervisorId { get; set; }
        public Therapist Supervisor { get; set; }

   
        public int? PractitionerId { get; set; }
        public Therapist Practitioner { get; set; }

        public DateTime RegisterDate { get; set; }

        public string DischargeDate { get; set; }

        public string Notes { get; set; }

        public string TherapistType { get; set; }
        

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        
        public TreatmentPlan TreatmentPlan { get; set; }
    }
}