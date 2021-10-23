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
    }
}