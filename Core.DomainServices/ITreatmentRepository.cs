using System.Collections.Generic;
using Core.Domain;

namespace Core.DomainServices
{
    public interface ITreatmentRepository
    {
        List<Treatment> GetAll();
        
        public void Add(Treatment treatment);
        void SaveChanges();
    }
}