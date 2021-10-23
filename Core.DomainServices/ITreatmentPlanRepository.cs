using System.Collections.Generic;
using Core.Domain;

namespace Core.DomainServices
{
    public interface ITreatmentPlanRepository
    {
        List<TreatmentPlan> GetAll();
        
        public void Add(TreatmentPlan treatmentPlan);
        void SaveChanges();
    }
}