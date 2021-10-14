using System.Linq;
using Core.Domain;

namespace Core.DomainServices
{
    public interface ITherapistRepository
    {
        IQueryable<Therapist> GetAll();
    }
}