using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IPatientFileRepository
    {
        IEnumerable<Patient> GetAll();

        Task<Patient> FindPatient(int? id);

        void RemovePatient(Patient patient);

        public void Add(PatientFile patientFile);
        
        void SaveChanges();
    }
}