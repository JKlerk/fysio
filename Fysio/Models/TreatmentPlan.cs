using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fysio.Validators;

namespace Fysio.Models
{
    public class TreatmentPlan
    {
        public int Id { get; set; }
        
        [Required]
        public int PatientFileId { get; set; }
        public virtual PatientFile PatientFile { get; set; }
        
        [Required]
        public int MaxTreatments { get; set; }

        public List<Treatment> Treatments;
        
        [Required]
        [DataType(DataType.Date)]
        [NotPast(ErrorMessage = "Start date can not be in the past")]
        public DateTime StartTime { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [NotPast(ErrorMessage = "End date can not be in the past")]
        public DateTime EndTime { get; set; }
    }
}