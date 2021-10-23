using System.Collections.Generic;

namespace Fysio.Models
{
    public class TreatmentViewModel
    {
        public List<Core.Domain.Therapist> Therapists { get; set; }
        public Core.Domain.TreatmentPlan TreatmentPlan { get; set; }
        public Core.Domain.Treatment Treatment { get; set; }
    }
}