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

        public async Task<Patient> Find(int? id)
        {
            return _context.Patients.First(p => p.Id == id);
        }

        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            
        }

        public void Update(Patient patient)
        {
            var oldData = _context.Patients.First(x => x.Id == patient.Id);
            _context.Entry(oldData).CurrentValues.SetValues(patient);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}