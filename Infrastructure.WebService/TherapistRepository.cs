using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class TherapistRepository : ITherapistRepository
    {
        private FysioContext _context;

        public TherapistRepository(FysioContext context)
        {
            _context = context;
        }
        public List<Therapist> GetAll()
        {
            return _context.Therapists.ToList();
        }

        public Therapist FindByEmail(string email)
        {
            return _context.Therapists.First(q => q.Email == email);
        }
    }
}