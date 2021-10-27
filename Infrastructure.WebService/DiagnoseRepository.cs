using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure.WebService
{
    public class DiagnoseRepository : IDiagnoseRepository
    {
        private static ApiContext _context;

        public DiagnoseRepository(ApiContext context)
        {
            _context = context;
        }

        public Diagnose Find(int id)
        {
            return _context.Diagnose.Find(id);
        }

        public Diagnose Update(Diagnose diagnose)
        {
            try
            {
                var oldData = _context.Diagnose.First(x => x.Id == diagnose.Id);
                _context.Entry(oldData).CurrentValues.SetValues(diagnose);
                _context.SaveChanges();
                return diagnose;
            }
            catch
            {
                return null;
            }
        }

        public List<Diagnose> GetAll()
        {
            return _context.Diagnose.ToList();
        }

        public Diagnose Add(Diagnose diagnose)
        {
            var data= _context.Diagnose.Add(diagnose).Entity;
            _context.SaveChanges();
            return data;
        }

        public List<Diagnose> AddRange(List<Diagnose> diagnoses)
        {
            List<Diagnose> returnList = new List<Diagnose>();
            foreach (var diagnose in diagnoses)
            {
                returnList.Add(_context.Diagnose.Add(diagnose).Entity);
            }

            _context.SaveChanges();
            return returnList;
        }

        public List<Diagnose> Delete()
        {
            List<Diagnose> deletedItems = new List<Diagnose>();

            foreach (var diagnose in _context.Diagnose)
            {
                deletedItems.Add(_context.Diagnose.Remove(diagnose).Entity);
                _context.SaveChanges();
            }
            
            return deletedItems;
        }

        public Diagnose Delete(int id)
        {
            try
            {
                var diagnose = _context.Diagnose.Find(id);
                _context.Diagnose.Remove(diagnose);
                _context.SaveChanges();
                return diagnose;
            }
            catch
            {
                return null;
            }
        }
    }
}