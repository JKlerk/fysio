using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IPatientFileRepository
    {
        IEnumerable<Patient> GetAll();

        Task<PatientFile> Find(int? id);

        public void Add(PatientFile patientFile);

        public void Update(PatientFile patientFile);
        
        void SaveChanges();
    }
}