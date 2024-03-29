﻿using System.Collections.Generic;
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

        public TreatmentPlan Find(int? id)
        {
            try
            {
                return _context.TreatmentPlans.First(tp => tp.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public TreatmentPlan FindWherePatientFileId(int id)
        {
            try
            {
                return _context.TreatmentPlans.First(tp => tp.PatientFileId == id);
            }
            catch
            {
                return null;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}