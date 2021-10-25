using System.Threading.Tasks;
using Core.DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fysio.Controllers
{
    [Authorize]
    public class TreatmentPlanController : Controller
    {

        private readonly ITreatmentPlanRepository _treatmentPlanRepository;
        private readonly ITreatmentRepository _treatmentRepository;
        
        public TreatmentPlanController (ITreatmentPlanRepository treatmentPlanRepository, ITreatmentRepository treatmentRepository)
        {
            _treatmentPlanRepository = treatmentPlanRepository;
            _treatmentRepository = treatmentRepository;
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
            
            // var patient = _patientRepository.FindPatient(id).Result;
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
            return View(tp);
        }
    }
}