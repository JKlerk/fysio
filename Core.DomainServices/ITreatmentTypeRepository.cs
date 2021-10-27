using System.Collections.Generic;
using Core.Domain;

namespace Core.DomainServices
{
    public interface ITreatmentTypeRepository
    {
        TreatmentType Find(int id);

        TreatmentType Update(TreatmentType treatmentType);
        
        List<TreatmentType> GetAll();

        TreatmentType Add(TreatmentType treatmentType);
        
        List<TreatmentType> AddRange(List<TreatmentType> treatmentTypes);

        List<TreatmentType> Delete();
        
        TreatmentType Delete(int id);
    }
}