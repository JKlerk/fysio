using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fysio.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITherapistRepository _therapistRepository;
        
        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITherapistRepository therapistRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _therapistRepository = therapistRepository;
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
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            
            if (user != null)
            {

                var therapist = _therapistRepository.FindByEmail(email);
                // sign in
                
                
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }


            return RedirectToAction("Login");
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string confirmPassword)
        {
            // if (password != confirmPassword) return View("Register");
         
            var user = new IdentityUser
            {
                UserName = "email",
                Email = email
            };
            user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, password);
            
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");   
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