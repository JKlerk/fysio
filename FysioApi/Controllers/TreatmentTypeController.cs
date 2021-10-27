using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainServices;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace FysioAPI.Controllers
{
    [ApiController]
    public class TreatmentTypeController : Controller
    {
        private readonly ITreatmentTypeRepository _treatmentTypeRepository;
        
        public TreatmentTypeController(ITreatmentTypeRepository treatmentTypeRepository)
        {
            _treatmentTypeRepository = treatmentTypeRepository;
        }
        
        // GET
        [SwaggerOperation(Summary = "Retrieves all TreatmentTypes. If provided with an Id a single TreatmentType will be returned")]
        [HttpGet]
        [Route("treatmenttype")]
        [Route("treatmenttype/{id?}")]
        public JsonResult Get(int? id)
        {
            return id != null ? Json(_treatmentTypeRepository.Find((int)id)) : Json(_treatmentTypeRepository.GetAll());
        }
        
        [SwaggerOperation(Summary = "Adds a new TreatmentType based on json input")]
        [HttpPost]
        [Route("treatmenttype")]
        public JsonResult Post([FromBody]TreatmentType treatmentType)
        {
            return Json(_treatmentTypeRepository.Add(treatmentType.ConvertToDomain()));
        }
        
        [SwaggerOperation(Summary = "Adds multiple TreatmentTypes based on json array input")]
        [HttpPut]
        [Route("treatmenttype")]
        public JsonResult Put([FromBody]List<TreatmentType> treatmentTypes)
        {
            List<Core.Domain.TreatmentType> convertedTreatmentTypes = new List<Core.Domain.TreatmentType>();
            foreach (var treatmentType in treatmentTypes)
            {
                convertedTreatmentTypes.Add(treatmentType.ConvertToDomain());
            }
            return Json(_treatmentTypeRepository.AddRange(convertedTreatmentTypes));
        }
        
        [SwaggerOperation(Summary = "Updates a single TreatmentType based on id and json input")]
        [HttpPut]
        [Route("treatmenttype/{id?}")]
        public JsonResult Put([FromBody] TreatmentType treatmentType, int id)
        {
            treatmentType.Id = id;
            var result = _treatmentTypeRepository.Update(treatmentType.ConvertToDomain());
            return result != null ? Json(result) : Json(NotFound());
        }
        
        [SwaggerOperation(Summary = "Deletes all TreatmentTypes")]
        [HttpDelete]
        [Route("treatmenttype")]
        public JsonResult Delete()
        {
            return Json(_treatmentTypeRepository.Delete());
        }
        
        [SwaggerOperation(Summary = "Removes a TreatmentType based on provided id")]
        [HttpDelete]
        [Route("treatmenttype/{id?}")]
        public JsonResult Delete(int id)
        {
            var result = _treatmentTypeRepository.Delete(id);
            return result == null ? Json(NotFound()) : Json(result);
        }
    }
}