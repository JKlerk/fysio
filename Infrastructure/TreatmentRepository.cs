using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly FysioContext _context;

        public TreatmentRepository(FysioContext context)
        {
            _context = context;
        }

        public List<Treatment> GetAll()
        {
            return _context.Treatments.ToList();
        }

        public void Add(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
        }

        public Treatment Find(int? id)
        {
            return _context.Treatments.Find(id);
        }

        public void Update(Treatment treatment)
        {
            var oldData = _context.Treatments.First(x => x.Id == treatment.Id);
            _context.Entry(oldData).CurrentValues.SetValues(treatment);
        }

        public void Remove(Treatment treatment)
        {
            _context.Treatments.Remove(treatment);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        
        public async Task<List<TreatmentType>> GetTreatmentTypes()
        {
            using HttpClient client = new HttpClient();
            string apiUrl = "https://localhost:5001/treatmenttype";
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TreatmentType>>(data);
            }
            return null;
        }
        
    }
}