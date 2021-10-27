using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure.WebService
{
    public class DiagnoseRepository : IDiagnoseRepository
    {
        private static ApiContext _context;

        public DiagnoseRepository(ApiContext context)
        {
            _context = context;
        }

        public List<Diagnose> GetAll()
        {
            return _context.Diagnose.ToList();
        }
    }
}