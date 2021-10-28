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
        private readonly ITreatmentRepository _treatmentRepository;
        
        public AppointmentController(IAppointmentRepository appointmentRepository, IPatientRepository patientRepository, ITherapistRepository therapistRepository, ITreatmentRepository treatmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
            _therapistRepository = therapistRepository;
            _treatmentRepository = treatmentRepository;
        }

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            if (User.IsInRole("Patient"))
            {
                var patient = _patientRepository.FindByName(User.Identity.Name);
                if (patient == null) return NotFound();
                return View(patient.Appointments);
            }
            
            var therapist = _therapistRepository.FindByName(User.Identity.Name);
            if (therapist == null) return NotFound();
            return View(therapist.Appointments);
        }
        
        [HttpGet]
        [Authorize(Roles = "Patient")]
        public IActionResult Create()
        {
            var patient = _patientRepository.FindByName(User.Identity.Name);
            if (patient == null) return NotFound();

            List<Models.Treatment> treatments = setTreatments(patient);
            
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            appointmentViewModel.Treatments = treatments;
            appointmentViewModel.AddTherapists(_therapistRepository.GetAll());
            

            return View(appointmentViewModel);
        }
        
        [HttpGet]
        [Authorize(Roles = "Therapist,Student")]
        public IActionResult CreatePatient(int id)
        {
            var patient = _patientRepository.Find(id);
            if (patient == null) return NotFound();
            
            List<Models.Treatment> treatments = setTreatments(patient);
            
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            appointmentViewModel.Treatments = treatments;
            appointmentViewModel.Patient = patient.ConvertToModel();

            return View("Create", appointmentViewModel);
        }
        
        
        
        // TODO: The selected date should be available in the therapist's schedule
        [HttpPost]
        public IActionResult Create(AppointmentViewModel appointmentViewModel)
        {
            if(ModelState.IsValid)
            {

                if (appointmentViewModel.Appointment.TreatmentId != null)
                {
                    var id = appointmentViewModel.Appointment.TreatmentId;
                    var tp = _treatmentRepository.Find(id);
                    List<Appointment> appointments;
                    if (User.IsInRole("Patient"))
                    {
                        appointments = _patientRepository.FindByName(User.Identity.Name).Appointments;
                    }
                    else
                    {
                        appointments = _patientRepository.Find(appointmentViewModel.Appointment.PatientId).Appointments;
                    }
                    
                    if (appointments.Count > tp.TreatmentPlan.MaxTreatments)
                    {
                        
                        if (User.IsInAnyRole("Therapist", "Student"))
                        {
                            var data = _patientRepository.Find(appointmentViewModel.Appointment.PatientId);
                            if (data == null) return NotFound();
                
                            List<Models.Treatment> treatments = setTreatments(data);

                            ModelState.AddModelError("Appointment.TreatmentId", "Maximum treatments have been reached");
                            appointmentViewModel.Treatments = treatments;
                            appointmentViewModel.Patient = data.ConvertToModel();
                            return View("Create", appointmentViewModel);
                        };
                        
                        var info = _patientRepository.FindByName(User.Identity.Name);
                        if (info == null) return NotFound();
            
                        List<Models.Treatment> treatments3 = setTreatments(info);
            
                        ModelState.AddModelError("Appointment.TreatmentId", "Maximum treatments have been reached");
                        appointmentViewModel.Treatments = treatments3;
                        appointmentViewModel.AddTherapists(_therapistRepository.GetAll());
                        return View(appointmentViewModel);
                    }
                }
                
                Patient oldPatient;
                
                if(User.IsInRole("Patient")){
                    oldPatient = _patientRepository.FindByName(User.Identity.Name);
                    if (oldPatient == null) return NotFound();
                }
                else
                {
                    oldPatient = _patientRepository.Find(appointmentViewModel.Appointment.PatientId);
                    if (oldPatient == null) return NotFound();
                }
                
                Appointment appointment = appointmentViewModel.Appointment.ConvertToDomain();
                appointment.PatientId = oldPatient.Id;
                if (User.IsInAnyRole("Therapist", "Student"))
                {
                    var therapist = _therapistRepository.FindByName(User.Identity.Name);
                    if (therapist == null) return NotFound();
                    appointment.TherapistId = therapist.Id;
                }
                appointment.AddedDate = DateTime.Now;
                _appointmentRepository.Add(appointment);
                _appointmentRepository.SaveChanges();
                return RedirectToAction("Index");
                
            }

            if (User.IsInAnyRole("Therapist", "Student"))
            {
                var data = _patientRepository.Find(appointmentViewModel.Appointment.PatientId);
                if (data == null) return NotFound();
                
                List<Models.Treatment> treatments = setTreatments(data);
                
                appointmentViewModel.Treatments = treatments;
                appointmentViewModel.Patient = data.ConvertToModel();

                return View("Create", appointmentViewModel);
            };
            
            var patient = _patientRepository.FindByName(User.Identity.Name);
            if (patient == null) return NotFound();

            List<Models.Treatment> treatments2 = setTreatments(patient);
            
            appointmentViewModel.Treatments = treatments2;
            appointmentViewModel.AddTherapists(_therapistRepository.GetAll());
            return View(appointmentViewModel);
        }
        
        
        // TODO: Implement this stuff
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appointment = _appointmentRepository.Find(id);
            if (appointment == null) return NotFound();
            if (Math.Abs(appointment.Date.Subtract(DateTime.Now).TotalHours) <= 24) return NotFound();

            Patient patient = _appointmentRepository.Find(id).Patient;
            if (patient == null) return NotFound();

            if (User.IsInRole("Patient"))
            {
                var checkPatient = _patientRepository.FindByName(User.Identity.Name);
                if (checkPatient == null) return NotFound();
                if (checkPatient.Id != patient.Id) return NotFound();
            }

            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
            appointmentViewModel.Appointment = appointment.ConvertToModel();

            var treatmentPlan = patient.PatientFile.TreatmentPlan;
            
            if (treatmentPlan == null) treatmentPlan = new TreatmentPlan();

            var t = treatmentPlan.ConvertToModel();
            if (treatmentPlan.Treatments == null) treatmentPlan.Treatments = new List<Treatment>();
            t.Treatments = new List<Models.Treatment>();
            foreach (var treatment in treatmentPlan.Treatments)
            {
                t.Treatments.Add(treatment.ConvertToModel());
            }
            
            appointmentViewModel.Treatments = t.Treatments;
            appointmentViewModel.AddTherapists(_therapistRepository.GetAll());

            return View(appointmentViewModel);
        }
        [HttpPost]
        public IActionResult Edit(AppointmentViewModel appointmentViewModel)
        {
            
            var oldAppointment = _appointmentRepository.Find(appointmentViewModel.Appointment.Id);
            if (oldAppointment == null) return NotFound();
            if (Math.Abs(oldAppointment.Date.Subtract(DateTime.Now).TotalHours) <= 24) return NotFound();

            if (ModelState.IsValid)
            {
                appointmentViewModel.Appointment.PatientId = oldAppointment.PatientId;
                _appointmentRepository.Update(appointmentViewModel.Appointment.ConvertToDomain());
                _appointmentRepository.SaveChanges();
                return Redirect("/appointment");
            }
            
            var treatmentPlan = oldAppointment.Patient.PatientFile.TreatmentPlan;
            if (treatmentPlan == null) treatmentPlan = new TreatmentPlan();

            var tm = treatmentPlan.ConvertToModel();
            if (treatmentPlan.Treatments == null) tm.Treatments = new List<Models.Treatment>();
            tm.Treatments = new List<Models.Treatment>();
            foreach (var treatment in treatmentPlan.Treatments)
            {
                tm.Treatments.Add(treatment.ConvertToModel());
            }
            
            appointmentViewModel.Treatments = tm.Treatments;
            appointmentViewModel.AddTherapists(_therapistRepository.GetAll());
            return View(appointmentViewModel);
        }
        
        //
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var appointment = _appointmentRepository.Find(id);
            if (appointment == null) return NotFound();
            if ((Math.Abs(appointment.Date.Subtract(DateTime.Now).TotalHours) <= 24)) RedirectToAction(nameof(Index));
            _appointmentRepository.Remove(appointment);
            _appointmentRepository.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }


        List<Models.Treatment> setTreatments(Patient patient)
        {
            var treatmentPlan = patient.PatientFile.TreatmentPlan;
            
            if (treatmentPlan == null) treatmentPlan = new TreatmentPlan();

            var t = treatmentPlan.ConvertToModel();
            if (treatmentPlan.Treatments == null) treatmentPlan.Treatments = new List<Treatment>();
            t.Treatments = new List<Models.Treatment>();
            foreach (var treatment in treatmentPlan.Treatments)
            {
                t.Treatments.Add(treatment.ConvertToModel());
            }

            return t.Treatments;
        }
    }
}