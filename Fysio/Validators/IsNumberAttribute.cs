using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Fysio.Validators
{
    public class IsNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if ((string)value == null) return true;
            return Regex.IsMatch((string)value, @"^\d+$");
        }
    }
}