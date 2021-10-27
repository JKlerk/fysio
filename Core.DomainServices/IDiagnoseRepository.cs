using System.Collections.Generic;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IDiagnoseRepository
    {
        Diagnose Find(int id);

        Diagnose Update(Diagnose diagnose);
        
        List<Diagnose> GetAll();

        Diagnose Add(Diagnose diagnose);
        
        List<Diagnose> AddRange(List<Diagnose> diagnoses);

        List<Diagnose> Delete();
        
        Diagnose Delete(int id);
    }
}