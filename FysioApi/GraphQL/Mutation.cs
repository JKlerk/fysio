using Core.DomainServices;

namespace FysioAPI.GraphQL
{
    public class Mutation
    {
        private readonly IDiagnoseRepository _diagnoseRepository;
        private readonly ITreatmentTypeRepository _treatmentTypeRepository;

        public Mutation(IDiagnoseRepository diagnoseRepository, ITreatmentTypeRepository treatmentTypeRepository)
        {
            _diagnoseRepository = diagnoseRepository;
            _treatmentTypeRepository = treatmentTypeRepository;
        }  
 
        
        public Core.Domain.Diagnose CreateDiagnose(Core.Domain.Diagnose diagnose) => _diagnoseRepository.Add(diagnose);  
        public Core.Domain.Diagnose DeleteDiagnose(Core.Domain.Diagnose diagnose) => _diagnoseRepository.Delete(diagnose.Id);
        
        public Core.Domain.TreatmentType CreateTreatmentType(Core.Domain.TreatmentType treatmentType) => _treatmentTypeRepository.Add(treatmentType);  
        public Core.Domain.TreatmentType DeleteTreatmentType(Core.Domain.TreatmentType treatmentType) => _treatmentTypeRepository.Delete(treatmentType.Id); 
    }
}