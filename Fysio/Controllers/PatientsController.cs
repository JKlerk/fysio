using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Fysio.Models;
using Fysio.Models.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Note = Core.Domain.Note;
using Patient = Fysio.Models.Patient;
using PatientFile = Fysio.Models.PatientFile;

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
        private readonly INoteRepository _noteRepository;

        public PatientsController(IPatientRepository patientRepository, ITherapistRepository therapistRepository, IPatientFileRepository patientFileRepository, ITreatmentPlanRepository treatmentPlanRepository, ITreatmentRepository treatmentRepository, INoteRepository noteRepository)
        {
            _patientRepository = patientRepository;
            _therapistRepository = therapistRepository;
            _patientFileRepository = patientFileRepository;
            _treatmentPlanRepository = treatmentPlanRepository;
            _treatmentRepository = treatmentRepository;
            _noteRepository = noteRepository;
        }

        // GET: Patients
        [HttpGet]
        [Authorize(Roles = "Therapist,Student")]
        public ActionResult<IEnumerable<Patient>> Index()
        {
            var patients = from s in _patientRepository.GetAll()
                select s;
            
            return View(patients);
        }

        public async Task<Core.Domain.Patient> AddTreatmentType(Core.Domain.Patient patient)
        {
            if (patient.PatientFile == null) return patient;
            if (patient.PatientFile.TreatmentPlan == null) return patient;
            if (patient.PatientFile.TreatmentPlan.Treatments.Count == 0) return patient;
            foreach (var treatment in patient.PatientFile.TreatmentPlan.Treatments)
            {
                var result = await _treatmentRepository.GetTreatmentType(Int32.Parse(treatment.Type)); 
                treatment.Type = result.Description;
            }

            return patient;
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var patient = _patientRepository.Find(id);
            if (patient == null) return NotFound();

            if (User.IsInAnyRole("Therapist", "Student"))
            {
                patient = await AddTreatmentType(patient);
                return View(patient);
            }
            
            
            if(!_patientRepository.isOwner(User.Identity.Name, patient)) return NotFound();
            
            patient = await AddTreatmentType(patient);
            return View(patient);
        }
        
        // GET: Patients/Create
        [HttpGet]
        [Authorize(Roles = "Therapist,Student")]
        public async Task<IActionResult> Create()
        {
            var patientViewModel = new PatientViewModel();

            patientViewModel.AddTherapists(_therapistRepository.GetAll());
            patientViewModel.Patient = new Patient();
            patientViewModel.Patient.PatientFile = new PatientFile();
            patientViewModel.Diagnoses = await _patientFileRepository.GetDiagnoses();
            patientViewModel.TreatmentTypes = await _treatmentRepository.GetTreatmentTypes();
            
            return View(patientViewModel);
        }
        
        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Therapist,Student")]
        public async Task<IActionResult> Create(PatientViewModel patientViewModel)
        {
            if (ModelState.IsValid)
            {
                Core.Domain.Patient patient = patientViewModel.Patient.ConvertToDomain();
                Core.Domain.PatientFile patientFile = patientViewModel.Patient.PatientFile.ConvertToDomain();
                Core.Domain.TreatmentPlan treatmentPlan = patientViewModel.TreatmentPlan.ConvertToDomain();
                Core.Domain.Treatment treatment = patientViewModel.Treatment.ConvertToDomain(); ;

                if (User.IsInRole("Student") && patientFile.SupervisorId == null)
                {
                    ModelState.AddModelError("SupervisorId", "The supervisor field is required");
                    patientViewModel.AddTherapists(_therapistRepository.GetAll());
                    return View("Create", patientViewModel);
                }
                
                patient.PatientNumber = Guid.NewGuid().ToString();
                _patientRepository.Add(patient);
                _patientRepository.SaveChanges();

                patientFile.PatientId = patient.Id;
                patientFile.Age = patient.CalculateAge();
                _patientFileRepository.Add(patientFile);
                _patientFileRepository.SaveChanges();

                var note = patientFile.Notes[0];
                note.PatientFileId = patientFile.Id;
                note.Placer = User.Identity.Name;
                note.CreatedOn = DateTime.Now;
                note.Id = 0;
                _noteRepository.Add(note);
                _noteRepository.SaveChanges();
                
                treatmentPlan.PatientFileId = patientFile.Id;
                _treatmentPlanRepository.Add(treatmentPlan);
                _treatmentPlanRepository.SaveChanges();
                
                treatment.TreatmentPlanId = treatmentPlan.Id;
                _treatmentRepository.Add(treatment);
                _treatmentRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            
            patientViewModel.TreatmentTypes = await _treatmentRepository.GetTreatmentTypes();
            patientViewModel.Diagnoses = await _patientFileRepository.GetDiagnoses();
            patientViewModel.AddTherapists(_therapistRepository.GetAll());
            return View("Create", patientViewModel);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound(); 
            
            var patient = _patientRepository.Find(id);
            if (patient == null) return NotFound();
            
            
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.Patient = patient.ConvertToModel();
            patientViewModel.AddTherapists(_therapistRepository.GetAll());
            patientViewModel.Diagnoses = await _patientFileRepository.GetDiagnoses();

            if(User.IsInAnyRole("Therapist", "Student")) return View(patientViewModel);
            if(!_patientRepository.isOwner(User.Identity.Name, patient)) return NotFound();
            
            return View(patientViewModel);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var username = User.Identity.Name;
            var patient = _patientRepository.FindByName(username);
            if (patient == null) return NotFound();
            return Redirect("/patients/details/" + patient.Id);
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientViewModel patientViewModel, int id)
        {
            if (id == 0) return NotFound();

            var oldPatient = _patientRepository.Find(id);
            if (oldPatient == null) return NotFound();
            
            if (ModelState.IsValid)
            {
                Core.Domain.Patient patient = patientViewModel.Patient.ConvertToDomain();
                patient.Id = id;
                if (User.IsInRole("Patient"))
                {
                    // if(!_patientRepository.isOwner(User.Identity.Name, patient)) return NotFound();
                    _patientRepository.Update(patient);
                    _patientRepository.SaveChanges();
                    return Redirect("/patients/details/" + patient.Id);
                }

                patient.Id = oldPatient.Id;
                _patientRepository.Update(patient);
                _patientRepository.SaveChanges();
                if (oldPatient.PatientFile != null)
                {
                    Core.Domain.PatientFile patientFile = patientViewModel.Patient.PatientFile.ConvertToDomain();
                    patientFile.PatientId = patient.Id;
                    patientFile.Age = patient.CalculateAge();
                    patientFile.Id = oldPatient.PatientFile.Id;
                    _patientFileRepository.Update(patientFile);
                    _patientFileRepository.SaveChanges();
                }
                else
                {
                    Core.Domain.PatientFile patientFile = patientViewModel.Patient.PatientFile.ConvertToDomain();
                    patientFile.PatientId = patient.Id;
                    patientFile.Age = patient.CalculateAge();
                    _patientFileRepository.Add(patientFile);
                    _patientFileRepository.SaveChanges();
                }

                return Redirect("/patients/details/" + patient.Id);
            }

            patientViewModel.AddTherapists(_therapistRepository.GetAll());
            patientViewModel.Diagnoses = await _patientFileRepository.GetDiagnoses();
            return View(patientViewModel);
        }
        
        [HttpGet]
        public IActionResult Note(int? id)
        {
            if (id == null) return NotFound(); 
            
            var patient = _patientRepository.Find(id);
            if (patient == null) return NotFound();

            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.Patient = patient.ConvertToModel();
            
            if(User.IsInAnyRole("Therapist", "Student")) return View(patientViewModel);

            return NotFound();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Note(PatientViewModel patientViewModel, int? id)
        {
            if (id == null) return NotFound(); 
            
            var patient = _patientRepository.Find(id);
            if (patient == null) return NotFound();

            var note = new Note();
            note.PatientFileId = patient.PatientFile.Id;
            note.Placer = User.Identity.Name;
            note.CreatedOn = DateTime.Now;
            note.Id = 0;
            note.Text = patientViewModel.PatientFile.Notes[0].Text;
            note.VisibleForPatient = patientViewModel.PatientFile.Notes[0].VisibleForPatient;
            _noteRepository.Add(note);
            _noteRepository.SaveChanges();
            
            if(User.IsInAnyRole("Therapist", "Student")) return Redirect("/patients/details/" + patient.Id);

            return NotFound();
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Therapist,Student")]
        public IActionResult DeleteConfirmed(int id)
        {
            var patient = _patientRepository.Find(id);
           
            _patientRepository.Remove(patient);
            _patientRepository.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }
    }
}
