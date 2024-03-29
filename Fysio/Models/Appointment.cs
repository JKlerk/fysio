﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Fysio.Validators;

namespace Fysio.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        
        [Required]
        [Available]
        public int TherapistId { get; set; }
        public virtual Therapist Therapist { get; set; }
        
        public int? TreatmentId { get; set; }
        public virtual Treatment Treatment { get; set; }
        
        public DateTime AddedDate { get; set; }
        
        [Required]
        [NotPast(ErrorMessage = "Your appointment can not be in the past")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}