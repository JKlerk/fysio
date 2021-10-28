using System.Linq;
using Core.DomainServices;
using FysioAPI.GraphQL.Types;
using GraphQL;
using GraphQL.Types;

namespace FysioAPI.GraphQL
{
    public class Query
    {
        private readonly IDiagnoseRepository _diagnoseRepository;
        private readonly ITreatmentTypeRepository _treatmentTypeRepository;
        
        public Query(IDiagnoseRepository diagnoseRepository, ITreatmentTypeRepository treatmentTypeRepository)
        {
            _diagnoseRepository = diagnoseRepository;
            _treatmentTypeRepository = treatmentTypeRepository;
        }

        // public IQueryable<Core.Domain.Diagnose> Diagnose() => _diagnoseRepository.GetAll().AsQueryable();
        
        [GraphQLMetadata("DiagnoseType")]
        public Core.Domain.Diagnose GetDiagnose(int id)
        {
            return _diagnoseRepository.Find(id);
            
        }

        public IQueryable<Core.Domain.TreatmentType> TreatmentType => _treatmentTypeRepository.GetAll().AsQueryable();  
    }
}