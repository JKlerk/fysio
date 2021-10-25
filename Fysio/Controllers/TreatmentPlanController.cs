using System;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Fysio.Models;
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

        public TreatmentPlanController (ITreatmentPlanRepository treatmentPlanRepository, ITreatmentRepository treatmentRepository, ITherapistRepository therapistRepository)
        {
            _treatmentPlanRepository = treatmentPlanRepository;
            _treatmentRepository = treatmentRepository;
            _therapistRepository = therapistRepository;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tp = _treatmentPlanRepository.Find(id).Result;
            return View(tp);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            if (_treatmentPlanRepository.FindWherePatientFileId(id).Status.ToString() != "Faulted") return RedirectToAction("Index");
            
            TreatmentViewModel treatmentViewModel = new TreatmentViewModel();
            treatmentViewModel.Therapists = _therapistRepository.GetAll();
            treatmentViewModel.TreatmentPlan = new TreatmentPlan();
            treatmentViewModel.TreatmentPlan.PatientFileId = id;
            return View(treatmentViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TreatmentViewModel treatmentPlanViewModel)
        {

            if (_treatmentPlanRepository.FindWherePatientFileId(treatmentPlanViewModel.TreatmentPlan.PatientFileId).Status.ToString() != "Faulted") return RedirectToAction("Index");
            

            if (ModelState.IsValid)
            {
                TreatmentPlan treatmentPlan = treatmentPlanViewModel.TreatmentPlan;
                Treatment treatment = treatmentPlanViewModel.Treatment;
                
                _treatmentPlanRepository.Add(treatmentPlan);
                _treatmentPlanRepository.SaveChanges();
                
                treatment.TreatmentPlanId = treatmentPlan.Id;
                treatment.AddedDate = DateTime.Now;
                _treatmentRepository.Add(treatment);
                _treatmentRepository.SaveChanges();
                
                return RedirectToAction("Index");
            }
            
            treatmentPlanViewModel.Therapists = _therapistRepository.GetAll();
            return View("Create", treatmentPlanViewModel);
        }
    }
}