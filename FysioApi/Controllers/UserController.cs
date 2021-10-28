using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Fysio.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Image = Core.Domain.Image;

namespace Fysio.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IPatientRepository _patientRepository;
        private readonly IImageRepository _imageRepository;
        // private readonly UserRepository _userRepository;
        
        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IPatientRepository patientRepository, IImageRepository imageRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _patientRepository = patientRepository;
            _imageRepository = imageRepository;
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
        public async Task<IActionResult> Login(UserModel um)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(um.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, um.Password, false, false);
                    if (result.Succeeded)
                    {
                        bool isPatient = await _userManager.IsInRoleAsync(user, "Patient");
                        if (isPatient)
                        {
                            var patient = _patientRepository.FindByEmail(user.Email);
                            return Redirect("/patients/details/" + patient.Id);
                        }

                        return RedirectToAction("Index");
                    }
                }
                ModelState.AddModelError("Email", "This user does not exist");
                return View(um);
            }
            return View(um);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserModel um)
        {
            // TODO: Added check if user is already registered
            if (ModelState.IsValid)
            {
                if (um.Password != um.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Password does not match");
                    return View(um);
                }

                var patient = _patientRepository.FindByEmail(um.Email);

                if (patient == null)
                {
                    ModelState.AddModelError("Email", "This user does not exist");
                    return View(um);
                }

                if (um.UserImage == null)
                {
                    ModelState.AddModelError("UserImage", "An Image is required");
                    return View(um);
                }

                if (um.UserImage.Length < 2097152)
                {
                    using (var ms = new MemoryStream())
                    using (var fs = um.UserImage.OpenReadStream())
                    {
                        await fs.CopyToAsync(ms);
                        
                        _imageRepository.Add(new Image()
                        {
                            PatientId = patient.Id, 
                            Src = $"data:{um.UserImage.ContentType};base64,{Convert.ToBase64String(ms.ToArray())}"
                        });
                        _imageRepository.SaveChanges();
                    }
                }
                else
                {
                    ModelState.AddModelError("UserImage", "The file is too large.");
                    return View(um);
                }

                var user = new IdentityUser
                {
                    UserName = Regex.Replace(patient.Name, @"\s+", "."),
                    Email = um.Email,
                    Id = patient.PatientNumber
                };
                user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, um.Password);

                var result = await _userManager.CreateAsync(user);
                var resultRole = await _userManager.AddToRoleAsync(user, "Patient");

                if (result.Succeeded && resultRole.Succeeded)
                {
                    var resultSignIn = await _signInManager.PasswordSignInAsync(user, um.Password, false, false);
                    if (resultSignIn.Succeeded)
                    {
                        return Redirect("/patients/details/" + patient.Id);
                    }
                }
            }

            return View(um);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        
        
    }
}