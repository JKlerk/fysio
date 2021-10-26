using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();

        Patient Find(int? id);

        void Remove(Patient patient);

        public void Add(Patient patient);

        public void Update(Patient patient);

        public Patient FindByEmail(string email);
        
        public Patient FindByName(string name);
        
        void SaveChanges();
    }
}