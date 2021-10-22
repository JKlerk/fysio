using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();

        Task<Patient> FindPatient(int? id);

        void RemovePatient(Patient patient);

        public void AddPatient(Patient patient);
        
        void SaveChanges();
    }
}