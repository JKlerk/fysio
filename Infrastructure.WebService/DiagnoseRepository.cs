using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure.WebService
{
    public class VektisRepository : IVektisRepository
    {
        private static ApiContext _context;

        public VektisRepository(ApiContext context)
        {
            _context = context;
        }

        public List<Vektis> GetAll()
        {
            return _context.Vektis.ToList();
        }
    }
}