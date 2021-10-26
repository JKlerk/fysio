using System;
using System.ComponentModel.DataAnnotations;

namespace Fysio.Validators
{
    public class NotFutureAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (DateTime.Now > (DateTime)value);
        }
    }
}