using System;
using System.ComponentModel.DataAnnotations;

namespace Fysio.Models
{
    public class Treatment
    {
        public int Id { get; set; }

        public int TreatmentPlanId { get; set; }
        public TreatmentPlan TreatmentPlan { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }
        
        public Therapist Therapist { get; set; }
    
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}