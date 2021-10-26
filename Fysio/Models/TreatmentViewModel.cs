using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Fysio.Models
{
    public class TreatmentViewModel : IViewModel
    {
        public List<Therapist> Therapists { get; set; }
        public TreatmentPlan TreatmentPlan { get; set; }
        public Treatment Treatment { get; set; }


        public void SetTherapist(List<Therapist> therapists)
        {
            Therapists = new List<Therapist>();
            Therapists = therapists;
        } 
    }
}