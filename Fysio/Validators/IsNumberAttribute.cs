using System.ComponentModel.DataAnnotations;

namespace Fysio.Validators
{
    public class IsNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is sbyte or byte or short or ushort or int or uint or long or ulong or float or double or decimal;
        }
    }
}