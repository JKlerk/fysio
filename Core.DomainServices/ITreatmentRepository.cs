using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface ITreatmentRepository
    {
        List<Treatment> GetAll();
        
        public void Add(Treatment treatment);
        
        public Treatment Find(int? id);
        
        public void Update(Treatment treatment);
        
        void Remove(Treatment treatment);
        
        void SaveChanges();

        public Task<List<TreatmentType>> GetTreatmentTypes();

        public Task<TreatmentType> GetTreatmentType(int id);
    }
}