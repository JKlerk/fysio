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

            var patient = _patientRepository.FindPatient(id).Result;
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
        public async Task<IActionResult> Create(PatientViewModel patientViewModel)
        {
        
            if (ModelState.IsValid)
            {
                Patient patient = patientViewModel.Patient;
                PatientFile patientFile = patientViewModel.PatientFile;
                TreatmentPlan treatmentPlan = patientViewModel.TreatmentPlan;
                Treatment treatment = patientViewModel.Treatment;
                
                patient.PatientNumber = Guid.NewGuid().ToString();
                _patientRepository.AddPatient(patient);
                _patientRepository.SaveChanges();
                patientFile.PatientId = patient.Id;
                patientFile.Age = patient.CalculateAge();
                _patientFileRepository.Add(patientFile);
                _patientRepository.SaveChanges();

                treatmentPlan.PatientFileId = patientFile.Id;
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
            
            var patient = await _patientRepository.FindPatient(id);
            if (patient == null)
            {
                return NotFound();
            }
            
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.Patient = patient;
            patientViewModel.PatientFile = patient.PatientFile;
            patientViewModel.Therapists = _therapistRepository.GetAll();

            return View(patientViewModel);
        }
        //
        // // POST: Patients/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Gender,Birthdate, Phonenumber, City, Street, Postalcode")] Patient patient)
        // {
        //     if (id != patient.Id)
        //     {
        //         return NotFound();
        //     }
        //
        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(patient);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!PatientExists(patient.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(patient);
        // }
        //
        // // GET: Patients/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var patient = await _context.Patients
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (patient == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return View(patient);
        // }
        //
        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _patientRepository.FindPatient(id);
           
            _patientRepository.RemovePatient(patient);
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
