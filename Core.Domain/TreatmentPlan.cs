using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class TreatmentPlan
    {
        public int Id { get; set; }
        
        public int PatientFileId { get; set; }
        public virtual PatientFile PatientFile { get; set; }

        public virtual List<Treatment> Treatments { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}