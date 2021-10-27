using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainServices;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FysioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreatmentTypeController : Controller
    {
        private readonly ITreatmentTypeRepository _treatmentTypeRepository;
        
        public TreatmentTypeController(ITreatmentTypeRepository treatmentTypeRepository)
        {
            _treatmentTypeRepository = treatmentTypeRepository;
        }
        
        // GET
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_treatmentTypeRepository.GetAll());
        }
    }
}