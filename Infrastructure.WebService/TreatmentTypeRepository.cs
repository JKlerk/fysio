using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure.WebService
{
    public class TreatmentTypeRepository : ITreatmentTypeRepository
    {
        private static ApiContext _context;

        public TreatmentTypeRepository(ApiContext context)
        {
            _context = context;
        }

        public TreatmentType Find(int id)
        {
            return _context.TreatmentType.Find(id);
        }

        public TreatmentType Update(TreatmentType treatmentType)
        {
            try
            {
                var oldData = _context.Diagnose.First(x => x.Id == treatmentType.Id);
                _context.Entry(oldData).CurrentValues.SetValues(treatmentType);
                _context.SaveChanges();
                return treatmentType;
            }
            catch
            {
                return null;
            }
        }

        public List<TreatmentType> GetAll()
        {
            return _context.TreatmentType.ToList();
        }

        public TreatmentType Add(TreatmentType treatmentType)
        {
            var data= _context.TreatmentType.Add(treatmentType).Entity;
            _context.SaveChanges();
            return data;
        }

        public List<TreatmentType> AddRange(List<TreatmentType> treatmentTypes)
        {
            List<TreatmentType> returnList = new List<TreatmentType>();
            foreach (var treatmentType in treatmentTypes)
            {
                returnList.Add(_context.TreatmentType.Add(treatmentType).Entity);
            }

            _context.SaveChanges();
            return returnList;
        }

        public List<TreatmentType> Delete()
        {
            List<TreatmentType> deletedItems = new List<TreatmentType>();

            foreach (var treatmentType in _context.TreatmentType)
            {
                deletedItems.Add(_context.TreatmentType.Remove(treatmentType).Entity);
                _context.SaveChanges();
            }
            
            return deletedItems;
        }

        public TreatmentType Delete(int id)
        {
            try
            {
                var treatmentType = _context.TreatmentType.Find(id);
                _context.TreatmentType.Remove(treatmentType);
                _context.SaveChanges();
                return treatmentType;
            }
            catch
            {
                return null;
            }
        }
    }
}