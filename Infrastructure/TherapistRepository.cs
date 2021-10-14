using System.Linq;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class TherapistRepository : ITherapistRepository
    {
        public IQueryable<Therapist> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}