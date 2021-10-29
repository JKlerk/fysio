using System;
using System.Threading.Tasks;
using Core.DomainServices;
using Fysio.Models;
using Fysio.Models.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Treatment = Core.Domain.Treatment;
using TreatmentPlan = Core.Domain.TreatmentPlan;

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
        public async Task<IActionResult> Create(int id)
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
            treatmentViewModel.TreatmentTypes = await _treatmentRepository.GetTreatmentTypes();
            treatmentViewModel.Treatment = new Models.Treatment{ TreatmentPlanId = id };
            treatmentViewModel.AddTherapists(_therapistRepository.GetAll());
            
            return View(treatmentViewModel);
        }
        
        [HttpPost]
        [Authorize(Roles = "Therapist,Student")]
        [Route("treatment/create")]
        public async Task<IActionResult> CreatePost(TreatmentViewModel treatmentViewModel)
        {
            if (ModelState.IsValid)
            {
                Treatment treatment = treatmentViewModel.Treatment.ConvertToDomain();
                treatment.AddedDate = DateTime.Now;

                TreatmentPlan treatmentPlan = _treatmentPlanRepository.Find(treatment.TreatmentPlanId);

                if (treatmentPlan.Treatments.Count >= treatmentPlan.MaxTreatments)
                {
                    treatmentViewModel.TreatmentTypes = await _treatmentRepository.GetTreatmentTypes();
                    ModelState.AddModelError("Treatment.Description", "Maximum treatments has been reached");
                    treatmentViewModel.AddTherapists(_therapistRepository.GetAll());
                    return View("Create", treatmentViewModel);
                }

                var newType = await _treatmentRepository.GetTreatmentType(Int32.Parse(treatment.Type));
                treatment.Type = newType.TreatmentCode;
                _treatmentRepository.Add(treatment);
                _treatmentRepository.SaveChanges();
        
                return Redirect("/treatmentplan/details/" + treatment.TreatmentPlanId);
            }
            treatmentViewModel.TreatmentTypes = await _treatmentRepository.GetTreatmentTypes();
            treatmentViewModel.AddTherapists(_therapistRepository.GetAll());
            return View("Create", treatmentViewModel);
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
        public IActionResult Edit(TreatmentViewModel treatmentViewModel, bool isFinished)
        {
            if (ModelState.IsValid)
            {
                Treatment treatment = treatmentViewModel.Treatment.ConvertToDomain();
                var old = _treatmentRepository.Find(treatment.Id);
                treatment.AddedDate = old.AddedDate;
                if(isFinished) treatment.FinishDate = DateTime.Now;
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