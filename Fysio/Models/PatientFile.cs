using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fysio.Models
{
    public class PatientFile
    {
        public int Id { get; set; }
        
        [Required]
        public int Age { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string DiagnoseCode { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int? InterviewerId { get; set; }
        public Therapist Interviewer { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int? SupervisorId { get; set; }
        public Therapist Supervisor { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int? PractitionerId { get; set; }
        public Therapist Practitioner { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }

        public string DischargeDate { get; set; }

        public string Notes { get; set; }

        [Required]
        public string TherapistType { get; set; }

        public string TreatmentPlan { get; set; }

        [Required]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public LinkedList<Treatment> Treatments { get; set; }
    }
}