using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class PatientRepository : IPatientRepository
    {

        private FysioContext _context;
        
        public PatientRepository(FysioContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }
        
       
    }
}