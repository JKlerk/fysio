using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Fysio.Models;
using Fysio.Models.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Appointment = Core.Domain.Appointment;
using Patient = Core.Domain.Patient;
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
        public IActionResult Index()
        {
            if (!User.IsInAnyRole("Therapist", "Student"))
            {
                var patient = _patientRepository.FindByName(User.Identity.Name);
                if (patient == null) return NotFound();
                return View(patient.Appointments);
            }
            
            var therapist = _therapistRepository.FindByName(User.Identity.Name);
            if (therapist == null) return NotFound();
            return View(therapist.Appointments);
        }

        // TODO: Therapist should be able to make appointments with patient
        [HttpGet]
        public IActionResult Create()
        {
            var patient = _patientRepository.FindByName(User.Identity.Name);
            if (patient == null) return NotFound();

            var treatmentPlan = patient.PatientFile.TreatmentPlan;
            if (treatmentPlan == null)
            {
                treatmentPlan = new TreatmentPlan();
            }

            var t = treatmentPlan.ConvertToModel();
            if (treatmentPlan.Treatments == null) t.Treatments = new List<Models.Treatment>();
            t.Treatments = new List<Models.Treatment>();
            foreach (var treatment in treatmentPlan.Treatments)
            {
                t.Treatments.Add(treatment.ConvertToModel());
            }
            
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            appointmentViewModel.Treatments = t.Treatments;
            appointmentViewModel.AddTherapists(_therapistRepository.GetAll());
            return View(appointmentViewModel);
        }
        
        // TODO: Implement this stuff
        // [HttpGet]
        // [Authorize(Roles = "Therapist,Student")]
        // public IActionResult CreatePatient()
        // {
        //     var patient = _patientRepository.FindByName(User.Identity.Name);
        //     if (patient == null) return NotFound();
        //
        //     var treatmentPlan = patient.PatientFile.TreatmentPlan;
        //
        //     if (treatmentPlan == null)
        //     {
        //         treatmentPlan = new TreatmentPlan
        //         {
        //             Treatments = new List<Treatment>()
        //         };
        //     }
        //     
        //     AppointmentViewModel appointmentViewModel = new AppointmentViewModel
        //     {
        //         Treatments = treatmentPlan.Treatments,
        //         Therapists = _therapistRepository.GetAll()
        //     };
        //     return View(appointmentViewModel);
        // }
        //
        // [HttpGet]
        // public IActionResult Edit(int id)
        // {
        //     Patient patient = null;
        //
        //     if (User.IsInAnyRole("Therapist", "Student"))
        //     {
        //         patient = _appointmentRepository.Find(id).Patient;
        //     }
        //     
        //     if (!User.IsInAnyRole("Therapist", "Student"))
        //     {
        //         patient = _patientRepository.FindByName(User.Identity.Name);
        //     }
        //     
        //     if (patient == null) return NotFound();
        //
        //     var treatmentPlan = patient.PatientFile.TreatmentPlan;
        //
        //     if (treatmentPlan == null)
        //     {
        //         treatmentPlan = new TreatmentPlan
        //         {
        //             Treatments = new List<Treatment>()
        //         };
        //     }
        //
        //     AppointmentViewModel appointmentViewModel = new AppointmentViewModel
        //     {
        //         Appointment =  _appointmentRepository.Find(id),
        //         Treatments = treatmentPlan.Treatments,
        //         Therapists = _therapistRepository.GetAll()
        //     };
        //     return View(appointmentViewModel);
        // }
        
        // // TODO: Implement edit appointment
        // [HttpPost]
        // public IActionResult Edit(AppointmentViewModel appointmentViewModel)
        // {
        //     var oldAppointment = _appointmentRepository.Find(appointmentViewModel.Appointment.Id);
        //     if (oldAppointment == null) return NotFound();
        //     
        //     Appointm
        //     
        //     // if (appointment.AddedDate.ToString("dd/MM/yyyy") != DateTime.Today.ToString("dd/MM/yyyy")) RedirectToAction(nameof(Index));
        //     return View(appointmentViewModel);
        // }
        
        
        // // TODO: The selected date should be available in the therapist's schedule
        // [HttpPost]
        // public IActionResult PostCreate(AppointmentViewModel appointmentViewModel)
        // {
        //     if(ModelState.IsValid){
        //         var username = User.Identity.Name;
        //         var patient = _patientRepository.FindByName(username);
        //         if (patient == null) return NotFound();
        //
        //         appointmentViewModel.Appointment.PatientId = patient.Id;
        //         appointmentViewModel.Appointment.AddedDate = DateTime.Now;
        //         _appointmentRepository.Add(appointmentViewModel.Appointment);
        //         _appointmentRepository.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return RedirectToAction("Create");
        // }
        //
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public IActionResult DeleteConfirmed(int id)
        // {
        //     var appointment = _appointmentRepository.Find(id);
        //     if (appointment.AddedDate.ToString("dd/MM/yyyy") != DateTime.Today.ToString("dd/MM/yyyy")) RedirectToAction(nameof(Index));
        //     _appointmentRepository.Remove(appointment);
        //     _appointmentRepository.SaveChanges();
        //     
        //     return RedirectToAction(nameof(Index));
        // }
    }
}