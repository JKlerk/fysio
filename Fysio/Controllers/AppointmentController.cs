using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Fysio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Appointment = Core.Domain.Appointment;
using Treatment = Core.Domain.Treatment;
using TreatmentPlan = Core.Domain.TreatmentPlan;

namespace Fysio.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly ITherapistRepository _therapistRepository;
        
        public AppointmentController(IAppointmentRepository appointmentRepository, IPatientRepository patientRepository, ITherapistRepository therapistRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
            _therapistRepository = therapistRepository;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var username = User.Identity.Name;
            var patient = await _patientRepository.FindByName(username);
            if (patient == null) return NotFound();
            return View(patient.Appointments);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var username = User.Identity.Name;
            var patient = await _patientRepository.FindByName(username);
            if (patient == null) return NotFound();

            var treatmentPlan = patient.PatientFile.TreatmentPlan;

            if (treatmentPlan == null)
            {
                treatmentPlan = new TreatmentPlan
                {
                    Treatments = new List<Treatment>()
                };
            }
            
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel
            {
                Treatments = treatmentPlan.Treatments,
                Therapists = _therapistRepository.GetAll()
            };
            return View(appointmentViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var username = User.Identity.Name;
            var patient = await _patientRepository.FindByName(username);
            if (patient == null) return NotFound();

            var treatmentPlan = patient.PatientFile.TreatmentPlan;

            if (treatmentPlan == null)
            {
                treatmentPlan = new TreatmentPlan
                {
                    Treatments = new List<Treatment>()
                };
            }
            
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel
            {
                Appointment =  _appointmentRepository.Find(id),
                Treatments = treatmentPlan.Treatments,
                Therapists = _therapistRepository.GetAll()
            };
            return View(appointmentViewModel);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> PostCreate(AppointmentViewModel appointmentViewModel)
        {
            if(ModelState.IsValid){
                var username = User.Identity.Name;
                var patient = await _patientRepository.FindByName(username);
                if (patient == null) return NotFound();

                appointmentViewModel.Appointment.PatientId = patient.Id;

                _appointmentRepository.Add(appointmentViewModel.Appointment);
                _appointmentRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
        
        // TODO: Add so you can only delete 24hours before
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var appointment = _appointmentRepository.Find(id);
           
            _appointmentRepository.Remove(appointment);
            _appointmentRepository.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }
    }
}