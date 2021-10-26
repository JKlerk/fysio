using System;
using System.Threading.Tasks;
using Core.DomainServices;
using Fysio.Models;
using Fysio.Models.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Treatment = Core.Domain.Treatment;

namespace Fysio.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly ITreatmentPlanRepository _treatmentPlanRepository;
        private readonly ITherapistRepository _therapistRepository;
        
        public TreatmentController(ITreatmentRepository treatmentRepository, ITherapistRepository therapistRepository, ITreatmentPlanRepository treatmentPlanRepository)
        {
            _treatmentRepository = treatmentRepository;
            _therapistRepository = therapistRepository;
            _treatmentPlanRepository = treatmentPlanRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Therapist,Student")]
        public IActionResult Create(int id)
        {
        
            if (id == 0)
            {
                return NotFound();
            }
            
            var treatmentPlan = _treatmentPlanRepository.Find(id);
            if (treatmentPlan == null)
            {
                return NotFound();
            }
        
            TreatmentViewModel treatmentViewModel = new TreatmentViewModel();
            treatmentViewModel.Treatment = new Models.Treatment{ TreatmentPlanId = id };
            treatmentViewModel.AddTherapists(_therapistRepository.GetAll());
            
            return View(treatmentViewModel);
        }
        
        
        [HttpPost]
        [Authorize(Roles = "Therapist,Student")]
        public IActionResult Create(TreatmentViewModel treatmentViewModel)
        {
            if (ModelState.IsValid)
            {
                Treatment treatment = treatmentViewModel.Treatment.ConvertToDomain();
                treatment.AddedDate = DateTime.Now;
                _treatmentRepository.Add(treatment);
                _treatmentRepository.SaveChanges();
        
                return Redirect("/treatmentplan/details/" + treatment.TreatmentPlanId);
            }
            treatmentViewModel.AddTherapists(_therapistRepository.GetAll());
            return View(treatmentViewModel);
        }
        
        [HttpGet]
        [Authorize(Roles = "Therapist,Student")]
        public IActionResult Edit(int id)
        {
        
            if (id == 0)
            {
                return NotFound();
            }
            
            var treatment = _treatmentRepository.Find(id);
            if (treatment == null)
            {
                return NotFound();
            }
        
            TreatmentViewModel treatmentViewModel = new TreatmentViewModel();
            treatmentViewModel.Treatment = treatment.ConvertToModel();
            treatmentViewModel.AddTherapists(_therapistRepository.GetAll());
            
            return View(treatmentViewModel);
        }
        
        [HttpPost]
        [Authorize(Roles = "Therapist,Student")]
        public IActionResult Edit(TreatmentViewModel treatmentViewModel)
        {
            if (ModelState.IsValid)
            {
                Treatment treatment = treatmentViewModel.Treatment.ConvertToDomain();
                var old = _treatmentRepository.Find(treatment.Id);
                treatment.AddedDate = old.AddedDate;
                _treatmentRepository.Update(treatment);
                _treatmentRepository.SaveChanges();
        
                return Redirect("/treatmentplan/details/" + treatment.TreatmentPlanId);
            }
            
            treatmentViewModel.AddTherapists(_therapistRepository.GetAll());
            return View(treatmentViewModel);
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Therapist,Student")]
        public IActionResult Delete(int id)
        {
            var treatment = _treatmentRepository.Find(id);

            if (treatment.AddedDate.ToString("dd/MM/yyyy") != DateTime.Today.ToString("dd/MM/yyyy")) return NotFound();
            
            _treatmentRepository.Remove(treatment);
            _treatmentRepository.SaveChanges();
            
            return Redirect("/treatmentplan/details/" + treatment.TreatmentPlanId);
        }
    }
}