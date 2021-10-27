using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure.WebService
{
    public class TreatmentTypeRepository : ITreatmentTypeRepository
    {
        private static ApiContext _context;

        public TreatmentTypeRepository(ApiContext context)
        {
            _context = context;
        }
        
        public List<TreatmentType> GetAll()
        {
            return _context.TreatmentType.ToList();
        }
    }
}