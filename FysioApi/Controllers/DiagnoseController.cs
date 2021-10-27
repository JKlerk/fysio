using System.Collections.Generic;
using Core.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace FysioAPI.Controllers
{
    [ApiController]
    public class DiagnoseController : Controller
    {
        private readonly IDiagnoseRepository _diagnoseRepository;
        
        public DiagnoseController(IDiagnoseRepository diagnoseRepository)
        {
            _diagnoseRepository = diagnoseRepository;
        }
        
        // Default actions
        [HttpGet]
        [Route("diagnose")]
        [Route("diagnose/{id?}")]
        public JsonResult Get(int? id)
        {
            return id != null ? Json(_diagnoseRepository.Find((int)id)) : Json(_diagnoseRepository.GetAll());
        }
        
        [HttpPost]
        [Route("diagnose")]
        public JsonResult Post([FromBody]Diagnose diagnose)
        {
            return Json(_diagnoseRepository.Add(diagnose.ConvertToDomain()));
        }
        
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
        
        [HttpPut]
        [Route("diagnose/{id?}")]
        public JsonResult Put([FromBody] Diagnose diagnose, int id)
        {
            diagnose.Id = id;
            var result = _diagnoseRepository.Update(diagnose.ConvertToDomain());
            return result != null ? Json(result) : Json(NotFound());
        }
        
        [HttpDelete]
        [Route("diagnose")]
        public JsonResult Delete()
        {
            return Json(_diagnoseRepository.Delete());
        }
        
        [HttpDelete]
        [Route("diagnose/{id?}")]
        public JsonResult Delete(int id)
        {
            var result = _diagnoseRepository.Delete(id);
            return result == null ? Json(NotFound()) : Json(result);
        }
        
    }
}