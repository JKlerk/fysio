using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.DomainServices;
using Infrastructure;

namespace Fysio.Validators
{
    public class UniqueEmailAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = (string)value;
            var therapistRepository = (ITherapistRepository) validationContext.GetService(typeof(ITherapistRepository));
            var patientRepository = (IPatientRepository) validationContext.GetService(typeof(IPatientRepository));


            if (therapistRepository.FindByEmail(email) == null && patientRepository.FindByEmail(email) == null)
            {
                return ValidationResult.Success;
            };
            
            return new ValidationResult("Email already exists");
        }
    }
}