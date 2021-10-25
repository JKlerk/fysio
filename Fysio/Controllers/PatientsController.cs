using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Fysio.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patient = Core.Domain.Patient;
using PatientFile = Core.Domain.PatientFile;
using Treatment = Core.Domain.Treatment;
using TreatmentPlan = Core.Domain.TreatmentPlan;


namespace Fysio.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ITherapistRepository _therapistRepository;
        private readonly IPatientFileRepository _patientFileRepository;
        private readonly ITreatmentPlanRepository _treatmentPlanRepository;
        private readonly ITreatmentRepository _treatmentRepository;

        public PatientsController(IPatientRepository patientRepository, ITherapistRepository therapistRepository, IPatientFileRepository patientFileRepository, ITreatmentPlanRepository treatmentPlanRepository, ITreatmentRepository treatmentRepository)
        {
            _patientRepository = patientRepository;
            _therapistRepository = therapistRepository;
            _patientFileRepository = patientFileRepository;
            _treatmentPlanRepository = treatmentPlanRepository;
            _treatmentRepository = treatmentRepository;
        }

        // GET: Patients
        [HttpGet]
        [Authorize(Roles = "Therapist")]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult<IEnumerable<Patient>>> Index()
        {
            var patients = from s in _patientRepository.GetAll()
                select s;
            
            return View(patients);
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var patient = await _patientRepository.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            // var _context = new FysioContext();
            //
            // var patient = await _patientRepository.Find(id)
            //     .FirstOrDefaultAsync(m => m.Id == id);
            // if (patient == null)
            // {
            //     return NotFound();
            // }
            //
            // return View(patient);
            return View(patient);
        }
        
        // GET: Patients/Create
        [HttpGet]
        [Authorize(Roles = "Therapist")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Create()
        {
            var patientViewModel = new PatientViewModel();
            patientViewModel.Therapists = _therapistRepository.GetAll();
            
            return View(patientViewModel);
        }
        
        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Therapist")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Create(PatientViewModel patientViewModel)
        {
        
            if (ModelState.IsValid)
            {
                Patient patient = patientViewModel.Patient;
                TreatmentPlan treatmentPlan = patientViewModel.TreatmentPlan;
                Treatment treatment = patientViewModel.Treatment;
                
                patient.PatientNumber = Guid.NewGuid().ToString();
                patient.PatientFile.Age = patient.CalculateAge();
                _patientRepository.Add(patient);
                _patientRepository.SaveChanges();

                treatmentPlan.PatientFileId = patient.PatientFile.Id;
                _treatmentPlanRepository.Add(treatmentPlan);
                _treatmentPlanRepository.SaveChanges();
                
                treatment.TreatmentPlanId = treatmentPlan.Id;
                _treatmentRepository.Add(treatment);
                _treatmentRepository.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                patientViewModel.Therapists = _therapistRepository.GetAll();
                return View("Create", patientViewModel);
            }
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var patient = await _patientRepository.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.Patient = patient;
            patientViewModel.Therapists = _therapistRepository.GetAll();
            
            return View(patientViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(PatientViewModel patientViewModel, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _patientRepository.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                if (patientViewModel.Patient.PatientFile == null)
                {
                    _patientRepository.Update(patientViewModel.Patient);
                    _patientRepository.SaveChanges();
                    return Redirect("/patients/details/" + patientViewModel.Patient.Id);
                }
                Patient newPatient = patientViewModel.Patient;
                newPatient.PatientFile.Id = patient.PatientFile.Id;
                newPatient.PatientFile.PatientId = patient.PatientFile.PatientId;
                newPatient.PatientFile.Age = patient.CalculateAge();
                
                _patientRepository.Update(newPatient);
                _patientRepository.SaveChanges();
                
                _patientFileRepository.Update(newPatient.PatientFile);
                _patientFileRepository.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(patientViewModel);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Therapist")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _patientRepository.Find(id);
           
            _patientRepository.Remove(patient);
            _patientRepository.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }
        //
        // private bool PatientExists(int id)
        // {
        //     return _context.Patients.Any(e => e.Id == id);
        // }
    }
}
