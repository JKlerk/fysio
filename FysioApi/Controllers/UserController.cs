using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Fysio.Models;
using Infrastructure.WebService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace FysioAPI.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        
        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost]
        [Route("user/login")]
        public async Task<IActionResult> Login([FromBody] UserModel um)
        {
            var token = GenToken(um);

            var user = await _userManager.FindByEmailAsync(um.Email);
            
            
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, um.Password, false, false);
                if (result.Succeeded)
                {
                    return Json(GenToken(um));
                }
            }

            return Json(NotFound());
        }
        
        private string GenToken(UserModel um)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, um.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, um.Email)
                }),
                Expires = DateTime.Now.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}