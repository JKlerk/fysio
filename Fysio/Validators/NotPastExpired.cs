using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Core.DomainServices;

namespace Fysio.Validators
{
    public class NotPastExpired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var treatmentPlan = (ITreatmentPlanRepository) validationContext.GetService(typeof(ITreatmentPlanRepository));
            var TreatmentPlanId = validationContext.ObjectInstance.GetType().GetProperty("TreatmentPlanId", BindingFlags.Public | BindingFlags.Instance);
            
            
            DateTime date = DateTime.Now;
            
            
            
            int treatmentPlanId;
            if (TreatmentPlanId != null)
            {
                treatmentPlanId = (int)TreatmentPlanId.GetValue(validationContext.ObjectInstance);

                var tp = treatmentPlan.Find(treatmentPlanId);
                if (date < tp.StartTime)
                {
                    return new ValidationResult("Treatment can not be added after the period has ended");
                }
                
                if (date > tp.EndTime)
                {
                    return new ValidationResult("Treatment can not be added after the period has ended");
                }
                
                return ValidationResult.Success;

            }
            
            
            return new ValidationResult("Treatment can not be added after the period has ended");
        }
    }
}