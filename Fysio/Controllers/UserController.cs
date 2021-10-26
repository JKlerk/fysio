using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fysio.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IPatientRepository _patientRepository;
        // private readonly UserRepository _userRepository;
        
        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IPatientRepository patientRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _patientRepository = patientRepository;
            // _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    bool isPatient = await _userManager.IsInRoleAsync(user, "Patient");
                    if (isPatient)
                    {
                        var patient = await _patientRepository.FindByEmail(user.Email);
                        return Redirect("/patients/details/" + patient.Id);
                    }
                    return RedirectToAction("Index");
                }
            }


            return RedirectToAction("Login");
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string email, string password, string confirmPassword, IFormFile userImage)
        {
            var patient = await _patientRepository.FindByEmail(email);

            if (patient == null)
            {
                return NotFound();
            }

            if (userImage.Length < 2097152)
            {
                using (var ms = new MemoryStream())
                using (var fs = userImage.OpenReadStream())
                {
                    await fs.CopyToAsync(ms);
                    patient.Image.Src = $"data:{userImage.ContentType};base64,{Convert.ToBase64String(ms.ToArray())}";
                    _patientRepository.Update(patient);
                    _patientRepository.SaveChanges();
                }
            }
            else
            {
                ModelState.AddModelError("File", "The file is too large.");
            }

            var user = new IdentityUser
            {
                UserName = Regex.Replace(patient.Name, @"\s+", "."),
                Email = email,
                Id = patient.PatientNumber
            };
            user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, password);
            
            var result = await _userManager.CreateAsync(user);
            var resultRole = await _userManager.AddToRoleAsync(user, "Patient");
            
            if (result.Succeeded && resultRole.Succeeded)
            {
                var resultSignIn = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (resultSignIn.Succeeded)
                {
                    return Redirect("/patients/details/" + patient.Id);
                }   
            }
            
            return RedirectToAction("Register");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        
        
    }
}