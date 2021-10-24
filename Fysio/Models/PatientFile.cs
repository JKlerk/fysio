﻿using System;
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
        public virtual Therapist Interviewer { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int? SupervisorId { get; set; }
        public virtual Therapist Supervisor { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int? PractitionerId { get; set; }
        public virtual Therapist Practitioner { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DischargeDate { get; set; }

        public string Notes { get; set; }

        [Required]
        public string TherapistType { get; set; }

        [Required]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public virtual TreatmentPlan TreatmentPlan { get; set; }
    }
}