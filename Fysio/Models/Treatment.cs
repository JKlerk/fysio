﻿using System;
using System.ComponentModel.DataAnnotations;
using Core.Domain;
using Fysio.Validators;

namespace Fysio.Models
{
    public class Treatment
    {
        public int Id { get; set; }

        public int TreatmentPlanId { get; set; }
        public virtual TreatmentPlan TreatmentPlan { get; set; }

        [Required]
        public string Type { get; set; }

        [NoteRequired]
        public string Description { get; set; }

        public TreatmentType TreatmentType { get; set; }
        
        [Required]
        public int TherapistId { get; set; }
        public virtual Therapist Therapist { get; set; }
    
        public virtual Appointment Appointment { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? FinishDate { get; set; }
    }
}