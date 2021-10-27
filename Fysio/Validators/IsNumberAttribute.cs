using System.ComponentModel.DataAnnotations;

namespace Fysio.Validators
{
    public class IsNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return int.TryParse((string)value, out _);
        }
    }
}