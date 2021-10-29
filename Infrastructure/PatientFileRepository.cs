using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class PatientFileRepository : IPatientFileRepository
    {

        private static FysioContext _context;

        public PatientFileRepository(FysioContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public async Task<PatientFile> Find(int? id)
        {
            return await _context.PatientFiles.FindAsync(id);
        }

        public void Add(PatientFile patientFile)
        {
            _context.PatientFiles.Add(patientFile);
        }

        public void Update(PatientFile patientFile)
        {
            var oldData = _context.PatientFiles.First(x => x.Id == patientFile.Id);
            _context.Entry(oldData).CurrentValues.SetValues(patientFile);
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<List<Diagnose>> GetDiagnoses()
        {
            using HttpClient client = new HttpClient();
            string apiUrl = "https://localhost:5001/diagnose";
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJwLnN0b29wQGF2YW5zLm5sIiwianRpIjoiMGI1Y2YyM2QtOWIxMS00NjIyLWFhODktYTg3NTMzZGM4ZTg0IiwiZW1haWwiOiJwLnN0b29wQGF2YW5zLm5sIiwibmJmIjoxNjM1NDY0Njk5LCJleHAiOjE2NjcwMDA2OTksImlhdCI6MTYzNTQ2NDY5OX0.HUMq17V4_3Zn9D4Sm9p-C4zC2xI5rPGPIc-9R4838pI");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Diagnose>>(data);
            }
            return null;
        }
    }
}