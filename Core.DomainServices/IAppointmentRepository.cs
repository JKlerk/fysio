using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.DomainServices
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAll();
        
        public void Add(Appointment appointment);
        
        public Appointment Find(int? id);

        public Task<List<Appointment>> FindByPatientId(int id);
        
        public void Update(Appointment appointment);
        
        void Remove(Appointment appointment);
        
        void SaveChanges();
    }
}