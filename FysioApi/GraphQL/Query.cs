using System.Collections.Generic;
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
        
        public List<Core.Domain.Diagnose>Diagnose(int? id)
        {
            if (id == null) return _diagnoseRepository.GetAll();
            var list = new List<Core.Domain.Diagnose>();
            list.Add(_diagnoseRepository.Find((int)id));
            return list;
        }

        public List<Core.Domain.TreatmentType>TreatmentType(int? id)
        {
            if (id == null) return _treatmentTypeRepository.GetAll();
            var list = new List<Core.Domain.TreatmentType>();
            list.Add(_treatmentTypeRepository.Find((int)id));
            return list;
        }
        
    }
}