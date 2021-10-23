using System.Collections.Generic;
using System.Linq;
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
            return _context.TreatmentPlans.ToList();
        }

        public void Add(TreatmentPlan treatmentPlan)
        {
            _context.TreatmentPlans.Add(treatmentPlan);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}