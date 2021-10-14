using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
    }
}