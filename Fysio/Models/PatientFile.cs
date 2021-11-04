using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fysio.Validators;

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
        
        public int? InterviewerId { get; set; }
        public virtual Therapist Interviewer { get; set; }
        
        public int? SupervisorId { get; set; }
        public virtual Therapist Supervisor { get; set; }
        
        public int? PractitionerId { get; set; }
        public virtual Therapist Practitioner { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Enter a valid date")]
        public DateTime RegisterDate { get; set; }
        
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Enter a valid date")]
        [NotPast(ErrorMessage = "Register date can not be in the past")]
        public DateTime DischargeDate { get; set; }

        public string PrivateNotes { get; set; }
        public string Notes { get; set; }

        [Required]
        public string TherapistType { get; set; }

        [Required]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public virtual TreatmentPlan TreatmentPlan { get; set; }
    }
}