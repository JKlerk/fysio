﻿using System;
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
        public virtual Therapist Interviewer { get; set; }

     
        public int? SupervisorId { get; set; }
        public virtual Therapist Supervisor { get; set; }

        public int? PractitionerId { get; set; }
        public virtual Therapist Practitioner { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime DischargeDate { get; set; }

        public virtual List<Note> Notes { get; set; }
        
        public string TherapistType { get; set; }
        
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        
        public virtual TreatmentPlan TreatmentPlan { get; set; }
    }
}