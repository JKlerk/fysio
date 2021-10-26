using System;
using System.ComponentModel.DataAnnotations;

namespace Fysio.Validators
{
    public class NotPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ((DateTime)value >= DateTime.Now);
        }
    }
}