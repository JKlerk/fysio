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
        private FysioContext _context;

        public TreatmentPlanRepository(FysioContext context)
        {
            _context = context;
        }

        public List<TreatmentPlan> GetAll()
        {
            return _context.TreatmentPlans.Include(tp => tp.Treatments).ToList();
        }

        public void Add(TreatmentPlan treatmentPlan)
        {
            _context.TreatmentPlans.Add(treatmentPlan);
        }
        
        public async Task<TreatmentPlan> Find(int? id)
        {
            return _context.TreatmentPlans.Where(tp => tp.Id == id).Include(tp => tp.Treatments).ThenInclude(t => t.Therapist).First();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}