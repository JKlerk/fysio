using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure
{
    public class TherapistRepository : ITherapistRepository
    {
        private readonly FysioContext _context;

        public TherapistRepository(FysioContext context)
        {
            _context = context;
        }
        public List<Therapist> GetAll()
        {
            return _context.Therapists.ToList();
        }

        public Therapist Find(int id)
        {
            try
            {
                return _context.Therapists.First(p => p.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public void Update(Therapist therapist)
        {
            var oldData = _context.Therapists.First(x => x.Id == therapist.Id);
            therapist.Email = oldData.Email;
            therapist.PhoneNumber = oldData.PhoneNumber;
            therapist.Name = oldData.Name;
            therapist.StudentNumber = oldData.StudentNumber;
            therapist.BigNumber = oldData.BigNumber;
            _context.Entry(oldData).CurrentValues.SetValues(therapist);
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

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}