using System.Collections.Generic;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IDiagnoseRepository
    {
        List<Diagnose> GetAll();
    }
}