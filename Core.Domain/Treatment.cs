using System;

namespace Core.Domain
{
    public class Treatment
    {
        public int Id { get; set; }

        public int TreatmentPlanId { get; set; }
        public TreatmentPlan TreatmentPlan { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public int TherapistId { get; set; }
        public Therapist Therapist { get; set; }
    
        public DateTime Date { get; set; }
    }

}