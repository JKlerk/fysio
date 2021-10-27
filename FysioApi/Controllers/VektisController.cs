using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IVektisRepository _vektisRepository;
        
        public DiagnoseController(IVektisRepository vektisRepository)
        {
            _vektisRepository = vektisRepository;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        // GET
        [HttpGet]
        public string Get()
        {
            string jsonString = JsonSerializer.Serialize(_vektisRepository.GetAll());
                
            return jsonString;
        }
    }
}