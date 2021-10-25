using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly FysioContext _context;

        public TreatmentRepository(FysioContext context)
        {
            _context = context;
        }

        public List<Treatment> GetAll()
        {
            return _context.Treatments.ToList();
        }

        public void Add(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
        }

        public async Task<Treatment> Find(int? id)
        {
            return _context.Treatments.Find(id);
        }

        public void Update(Treatment treatment)
        {
            var oldData = _context.Treatments.First(x => x.Id == treatment.Id);
            _context.Entry(oldData).CurrentValues.SetValues(treatment);
        }

        public void Remove(Treatment treatment)
        {
            _context.Treatments.Remove(treatment);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        
        
    }
}