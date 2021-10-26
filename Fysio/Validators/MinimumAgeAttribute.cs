using System;
using System.ComponentModel.DataAnnotations;

namespace Fysio.Validators
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _age;
        
        public MinimumAgeAttribute(int minimumAge)
        {
            _age = minimumAge;
        }

        public override bool IsValid(object value)
        {
            var date = (DateTime)value;
            DateTime now = DateTime.Now;
            int age = now.Year - date.Year;
            if (now.Month < date.Month || (now.Month == date.Month && now.Day < date.Day))
                age--;
            return age >= _age;
        }
    }
}