using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class PatientFileRepository : IPatientFileRepository
    {

        private static FysioContext _context;

        public PatientFileRepository(FysioContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public async Task<PatientFile> Find(int? id)
        {
            return await _context.PatientFiles.FindAsync(id);
        }

        public void Add(PatientFile patientFile)
        {
            _context.PatientFiles.Add(patientFile);
        }

        public void Update(PatientFile patientFile)
        {
            var oldData = _context.PatientFiles.First(x => x.Id == patientFile.Id);
            _context.Entry(oldData).CurrentValues.SetValues(patientFile);
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        
    }
}