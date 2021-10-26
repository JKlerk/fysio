using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime StartTime { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }
    }
}