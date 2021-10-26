using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface ITreatmentPlanRepository
    {
        List<TreatmentPlan> GetAll();
        
        public void Add(TreatmentPlan treatmentPlan);
        
        public void Update(TreatmentPlan treatmentPlan);
        
        void SaveChanges();

        public TreatmentPlan Find(int? id);

        public TreatmentPlan FindWherePatientFileId(int id);
    }
}