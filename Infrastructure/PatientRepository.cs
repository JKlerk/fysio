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

        private static FysioContext _context;

        public PatientRepository(FysioContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public async Task<Patient> FindPatient(int? id)
        {
            return _context.Patients.Where(b => b.Id == id).Include("PatientFile").First();
            // return await _context.Patients
            //     .FirstOrDefaultAsync(m => m.Id == id);
        }

        public void RemovePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}