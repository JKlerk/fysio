using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fysio.Models
{
    public class PatientFile
    {
        public int Id { get; set; }
        
        public int Age { get; set; }

        public string Description { get; set; }

        public string DiagnoseCode { get; set; }

        [ForeignKey("Id")]
        public int? InterviewerId { get; set; }
        public Therapist Interviewer { get; set; }

        [ForeignKey("Id")]
        public int? SupervisorId { get; set; }
        public Therapist Supervisor { get; set; }

        [ForeignKey("Id")]
        public int? PractitionerId { get; set; }
        public Therapist Practitioner { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }

        public string DischargeDate { get; set; }

        public string Notes { get; set; }

        public string TreatmentPlan { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public LinkedList<Treatment> Treatments { get; set; }
    }
}