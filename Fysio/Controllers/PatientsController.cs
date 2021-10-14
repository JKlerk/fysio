using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.AspNetCore.Mvc;


namespace Fysio.Controllers
{
    public class PatientsController : Controller
    {
        private IPatientRepository _patientRepository;
        

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // GET: Patients
        public async Task<ActionResult<IEnumerable<Patient>>> Index()
        {
            var students = from s in _patientRepository.GetAll()
                select s;
            
            return View(students);
            // return View(_patientRepository.GetAll());
            
            // return View(await _context.Patients.Include(e => e.PatientFiles).ToListAsync());
        }

        // GET: Patients/Details/5
        // public async Task<IActionResult> Details(int? id)
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
        // // GET: Patients/Create
        // public async Task<IActionResult> Create()
        // {
        //     return View(await _context.Therapists.ToListAsync());
        // }
        //
        // // POST: Patients/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create(Patient patient)
        // {
        //
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(patient);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View();
        // }
        // // public async Task<IActionResult> Create([Bind("Id,Name,Email,Gender,Birthdate")] Patient patient)
        // // {
        // //     if (ModelState.IsValid)
        // //     {
        // //         _context.Add(patient);
        // //         await _context.SaveChangesAsync();
        // //         return RedirectToAction(nameof(Index));
        // //     }
        // //     return View(patient);
        // // }
        //
        // // GET: Patients/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var patient = await _context.Patients.FindAsync(id);
        //     if (patient == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(patient);
        // }
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
        // // POST: Patients/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var patient = await _context.Patients.FindAsync(id);
        //     _context.Patients.Remove(patient);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }
        //
        // private bool PatientExists(int id)
        // {
        //     return _context.Patients.Any(e => e.Id == id);
        // }
    }
}
