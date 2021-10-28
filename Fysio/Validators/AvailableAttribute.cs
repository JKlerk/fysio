using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Core.Domain;
using Core.DomainServices;

namespace Fysio.Validators
{
    public class AvailableAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var therapistId = (int)value;
            var therapistRepository = (ITherapistRepository) validationContext.GetService(typeof(ITherapistRepository));

            var property = validationContext.ObjectInstance.GetType().GetProperty("Date", BindingFlags.Public | BindingFlags.Instance);
            DateTime? date = null;
            if (property != null)
            {
                date = (DateTime?)property.GetValue(validationContext.ObjectInstance);

                List<Appointment> appointments = therapistRepository.Find(therapistId).Appointments;
                var result = appointments.Where(x => x.Date ==  date);
                if(!result.Any()) return ValidationResult.Success;
            }

            return new ValidationResult("This therapist is not available at this time");
        }
    }
}