using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
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