using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Core.DomainServices;

namespace Fysio.Validators
{
    public class NoteRequired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var treatmentRepo = (ITreatmentRepository) validationContext.GetService(typeof(ITreatmentRepository));

            var property = validationContext.ObjectInstance.GetType().GetProperty("Type", BindingFlags.Public | BindingFlags.Instance);


            string treatmentTypeId;
            
            if (property != null)
            {
                treatmentTypeId = (string)property.GetValue(validationContext.ObjectInstance);

                var result = treatmentRepo.GetTreatmentType(Int32.Parse(treatmentTypeId)).Result;

                if (result.ExplanationRequired == "Ja")
                {
                    if ((string)value == null)
                    {
                        return new ValidationResult("Description is required for this treatment");
                    }
                    return ValidationResult.Success;
                }
                
                
                return ValidationResult.Success;

            }
            
            
            return new ValidationResult("Treatment can not be added after the period has ended");
        }
    }
}