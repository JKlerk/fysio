using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace FysioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiagnoseController : Controller
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        // GET
        [HttpGet]
        public string Get()
        {
            return "test";
        }
    }
}