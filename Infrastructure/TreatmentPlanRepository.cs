using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class TreatmentPlanRepository : ITreatmentPlanRepository
    {
        private readonly FysioContext _context;

        public TreatmentPlanRepository(FysioContext context)
        {
            _context = context;
        }

        public List<TreatmentPlan> GetAll()
        {
            return _context.TreatmentPlans.ToList();
        }

        public void Add(TreatmentPlan treatmentPlan)
        {
            _context.TreatmentPlans.Add(treatmentPlan);
        }

        public void Update(TreatmentPlan treatmentPlan)
        {
            _context.TreatmentPlans.Update(treatmentPlan);
        }

        public async Task<TreatmentPlan> Find(int? id)
        {
            return _context.TreatmentPlans.First(tp => tp.Id == id);
        }

        public async Task<TreatmentPlan> FindWherePatientFileId(int id)
        {
            return _context.TreatmentPlans.First(tp => tp.PatientFileId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}