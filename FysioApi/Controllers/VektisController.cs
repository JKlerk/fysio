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
    public class DiagnoseController : Controller
    {
        private readonly IDiagnoseRepository _diagnoseRepository;
        
        public DiagnoseController(IDiagnoseRepository dianoseRepository)
        {
            _diagnoseRepository = dianoseRepository;
        }
        
        // GET
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_diagnoseRepository.GetAll());
        }
    }
}