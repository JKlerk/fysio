using System.Collections.Generic;
using Core.Domain;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Fysio.Models
{
    public class TreatmentViewModel : IViewModel
    {
        public List<Therapist> Therapists { get; set; }
        public TreatmentPlan TreatmentPlan { get; set; }
        public Treatment Treatment { get; set; }
        
        public List<TreatmentType> TreatmentTypes;

        public void SetTherapist(List<Therapist> therapists)
        {
            Therapists = new List<Therapist>();
            Therapists = therapists;
        } 
    }
}