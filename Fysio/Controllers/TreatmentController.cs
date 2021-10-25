using System;
using System.Threading.Tasks;
using Core.DomainServices;
using Fysio.Models;
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
        public async Task<IActionResult> Create(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            
            var treatmentPlan = await _treatmentPlanRepository.Find(id);
            if (treatmentPlan == null)
            {
                return NotFound();
            }

            TreatmentViewModel treatmentViewModel = new TreatmentViewModel();
            treatmentViewModel.Treatment = new Treatment { TreatmentPlanId = id };
            treatmentViewModel.Therapists = _therapistRepository.GetAll();
            
            return View(treatmentViewModel);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> PostCreate(TreatmentViewModel treatmentViewModel)
        {
            if (ModelState.IsValid)
            {
                Treatment treatment = new Treatment();
                treatment.Id = treatmentViewModel.Treatment.Id;
                
                
                treatment.AddedDate = DateTime.Now;
                _treatmentRepository.Add(treatment);
                _treatmentRepository.SaveChanges();

                return Redirect("/treatmentplan/details/" + treatment.TreatmentPlanId);
            }
            
            return RedirectToAction("Create");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            
            var treatment = await _treatmentRepository.Find(id);
            if (treatment == null)
            {
                return NotFound();
            }

            TreatmentViewModel treatmentViewModel = new TreatmentViewModel();
            treatmentViewModel.Treatment = treatment;
            treatmentViewModel.Therapists = _therapistRepository.GetAll();
            
            return View(treatmentViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostEdit(Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                var old = await _treatmentRepository.Find(treatment.Id);
                treatment.AddedDate = old.AddedDate;
                _treatmentRepository.Update(treatment);
                _treatmentRepository.SaveChanges();

                return Redirect("/treatmentplan/details/" + treatment.TreatmentPlanId);
            }
            
            return RedirectToAction("Edit");
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var treatment = await _treatmentRepository.Find(id);

            if (treatment.AddedDate.ToString("dd/MM/yyyy") != DateTime.Today.ToString("dd/MM/yyyy")) return NotFound();
            
            _treatmentRepository.Remove(treatment);
            _treatmentRepository.SaveChanges();
            
            return Redirect("/treatmentplan/details/" + treatment.TreatmentPlanId);
        }
    }
}