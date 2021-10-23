using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fysio.Models
{
    public class TreatmentPlan
    {
        public int Id { get; set; }
        
        public int PatientFileId { get; set; }
        public PatientFile PatientFile { get; set; }
        
        public List<Treatment> Treatments;
        
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }
    }
}