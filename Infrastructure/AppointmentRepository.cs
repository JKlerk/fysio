using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly FysioContext _context;

        public AppointmentRepository(FysioContext context)
        {
            _context = context;
        }

        public List<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
        }

        public Appointment Find(int? id)
        {
            return _context.Appointments.Find(id);
        }

        public async Task<List<Appointment>> FindByPatientId(int id)
        {
            return await _context.Appointments.Where(x => x.PatientId == id).ToListAsync();
        }

        public void Update(Appointment appointment)
        {
            var oldData = _context.Appointments.First(x => x.Id == appointment.Id);
            _context.Entry(oldData).CurrentValues.SetValues(appointment);
        }

        public void Remove(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}