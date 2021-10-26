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

        public Therapist FindByName(string name)
        {
            name = name.Replace(".", " ");
            try
            {
                return _context.Therapists.First(x => x.Name == name);
            }
            catch
            {
                return null;
            }
        }

        public Therapist FindByEmail(string email)
        {
            try
            {
                return _context.Therapists.First(q => q.Email == email);
            }
            catch
            {
                return null;
            }
        }
    }
}