using System.Collections.Generic;
using Core.DomainServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FysioAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class DiagnoseController : Controller
    {
        private readonly IDiagnoseRepository _diagnoseRepository;
        
        public DiagnoseController(IDiagnoseRepository diagnoseRepository)
        {
            _diagnoseRepository = diagnoseRepository;
        }
        
        [SwaggerOperation(Summary = "Retrieves all diagoses. If provided with an Id a single Diagnose will be returned")]
        [HttpGet]
        [Route("diagnose")]
        [Route("diagnose/{id?}")]
        public JsonResult Get(int? id)
        {
            return id != null ? Json(_diagnoseRepository.Find((int)id)) : Json(_diagnoseRepository.GetAll());
        }
        
        [SwaggerOperation(Summary = "Adds a new diagnose based on json input")]
        [HttpPost]
        [Route("diagnose")]
        public JsonResult Post([FromBody]Diagnose diagnose)
        {
            return Json(_diagnoseRepository.Add(diagnose.ConvertToDomain()));
        }
        
        [SwaggerOperation(Summary = "Adds multiple diagnoses based on json array input")]
        [HttpPut]
        [Route("diagnose")]
        public JsonResult Put([FromBody] List<Diagnose> diagnoses)
        {
            List<Core.Domain.Diagnose> convertedDiagnoses = new List<Core.Domain.Diagnose>();
            foreach (var diagnose in diagnoses)
            {
                convertedDiagnoses.Add(diagnose.ConvertToDomain());
            }
            return Json(_diagnoseRepository.AddRange(convertedDiagnoses));
        }
        
        [SwaggerOperation(Summary = "Updates a single diagnose based on id and json input")]
        [HttpPut]
        [Route("diagnose/{id?}")]
        public JsonResult Put([FromBody] Diagnose diagnose, int id)
        {
            diagnose.Id = id;
            var result = _diagnoseRepository.Update(diagnose.ConvertToDomain());
            return result != null ? Json(result) : Json(NotFound());
        }
        
        [SwaggerOperation(Summary = "Deletes all diagnoses")]
        [HttpDelete]
        [Route("diagnose")]
        public JsonResult Delete()
        {
            return Json(_diagnoseRepository.Delete());
        }
        
        [SwaggerOperation(Summary = "Removes a diagnose based on provided id")]
        [HttpDelete]
        [Route("diagnose/{id?}")]
        public JsonResult Delete(int id)
        {
            var result = _diagnoseRepository.Delete(id);
            return result == null ? Json(NotFound()) : Json(result);
        }
        
    }
}