using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Fysio.Models
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
        public IFormFile UserImage { get; set; }
    }
}