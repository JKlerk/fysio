using System;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Fysio.Models;
using Fysio.Models.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Treatment = Core.Domain.Treatment;
using TreatmentPlan = Core.Domain.TreatmentPlan;

namespace Fysio.Controllers
{
    [Authorize]
    public class TreatmentPlanController : Controller
    {

        private readonly ITreatmentPlanRepository _treatmentPlanRepository;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly ITherapistRepository _therapistRepository;
        private readonly IPatientRepository _patientRepository;
        
        public TreatmentPlanController (ITreatmentPlanRepository treatmentPlanRepository, ITreatmentRepository treatmentRepository, ITherapistRepository therapistRepository, IPatientRepository patientRepository)
        {
            _treatmentPlanRepository = treatmentPlanRepository;
            _treatmentRepository = treatmentRepository;
            _therapistRepository = therapistRepository;
            _patientRepository = patientRepository;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound(); 

            var tp = _treatmentPlanRepository.Find(id);
            if (tp == null) return NotFound();

            if (tp.Treatments.Count != 0)
            {
                foreach (var treatment in tp.Treatments)
                {
                    var result = await _treatmentRepository.GetTreatmentType(Int32.Parse(treatment.Type));
                    treatment.Type = result.Description;
                }
            }
            
            if (User.IsInAnyRole("Therapist", "Student")) return View(tp);

            if(!_patientRepository.isOwner(User.Identity.Name, tp.PatientFile.Patient)) return NotFound();

            return View(tp);
        }

        [HttpGet]
        [Authorize(Roles = "Therapist,Student")]
        public async Task<IActionResult> Create(int id)
        {
            TreatmentViewModel treatmentViewModel = new TreatmentViewModel();
            
            treatmentViewModel.AddTherapists(_therapistRepository.GetAll());
            treatmentViewModel.TreatmentPlan = new Models.TreatmentPlan();
            treatmentViewModel.TreatmentPlan.PatientFileId = id;
            treatmentViewModel.TreatmentTypes = await _treatmentRepository.GetTreatmentTypes();
            return View(treatmentViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Therapist,Student")]
        public async Task<IActionResult> Create(TreatmentViewModel treatmentPlanViewModel)
        {

            if (ModelState.IsValid)
            {
                TreatmentPlan treatmentPlan = treatmentPlanViewModel.TreatmentPlan.ConvertToDomain();
                Treatment treatment = treatmentPlanViewModel.Treatment.ConvertToDomain();
                
                _treatmentPlanRepository.Add(treatmentPlan);
                _treatmentPlanRepository.SaveChanges();
                
                treatment.TreatmentPlanId = treatmentPlan.Id;
                treatment.AddedDate = DateTime.Now;
                _treatmentRepository.Add(treatment);
                _treatmentRepository.SaveChanges();
                
                return Redirect("/treatmentplan/details/" + treatmentPlan.Id);
            }
            
            treatmentPlanViewModel.TreatmentTypes = await _treatmentRepository.GetTreatmentTypes();
            treatmentPlanViewModel.AddTherapists(_therapistRepository.GetAll());;
            return View("Create", treatmentPlanViewModel);
        }
    }
}