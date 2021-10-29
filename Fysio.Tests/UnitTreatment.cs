using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using Core.DomainServices;
using Fysio.Controllers;
using Fysio.Models;
using Fysio.Models.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Appointment = Core.Domain.Appointment;
using Patient = Core.Domain.Patient;
using PatientFile = Core.Domain.PatientFile;
using Therapist = Core.Domain.Therapist;
using Treatment = Core.Domain.Treatment;
using TreatmentPlan = Core.Domain.TreatmentPlan;

namespace Fysio.Tests
{
    public class UnitTestTreatment
    {
        [Fact]
        public void UserNotPatientWhenAddingPatient()
        {
            
        }

        [Fact]
        public void TreatmentRequiresNote()
        {
            
        }

        public bool validateModelState(object model, IServiceProvider service)
        {
            var context = new ValidationContext(model, service, null);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, context, results, true);
        }
    }
    
    
    
}
