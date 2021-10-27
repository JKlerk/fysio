using System.Collections.Generic;
using Core.Domain;

namespace Core.DomainServices
{
    public interface ITreatmentTypeRepository
    {
        List<TreatmentType> GetAll();
    }
}