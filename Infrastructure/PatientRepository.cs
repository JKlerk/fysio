using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public Patient Find(int? id)
        {
            try
            {
                return _context.Patients.First(p => p.Id == id);
            }
            catch
            {
                return null;
            }
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

        public Patient FindByEmail(string email)
        {
            try
            {
                return _context.Patients.First(x => x.Email == email);
            }
            catch
            {
                return null;
            }
        }

        public Patient FindByName(string name)
        {
            name = name.Replace(".", " ");
            try
            {
                return _context.Patients.First(x => x.Name == name);
            }
            catch
            {
                return null;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}