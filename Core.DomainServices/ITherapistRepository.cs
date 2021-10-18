using System.Collections.Generic;
using System.Linq;
using Core.Domain;

namespace Core.DomainServices
{
    public interface ITherapistRepository
    {
        List<Therapist> GetAll();
    }
}