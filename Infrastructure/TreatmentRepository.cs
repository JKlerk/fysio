using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private FysioContext _context;

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

        public void Update(Treatment treatment)
        {
            _context.Treatments.Update(treatment);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}