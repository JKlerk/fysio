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

        public async Task<Patient> FindPatient(int? id)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public void RemovePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

        public void Add(PatientFile patientFile)
        {
            _context.PatientFiles.Add(patientFile);
        }
        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        
    }
}