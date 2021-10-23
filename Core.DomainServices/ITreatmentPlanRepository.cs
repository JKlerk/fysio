using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface ITreatmentPlanRepository
    {
        List<TreatmentPlan> GetAll();
        
        public void Add(TreatmentPlan treatmentPlan);
        void SaveChanges();

        public Task<TreatmentPlan> Find(int? id);
    }
}